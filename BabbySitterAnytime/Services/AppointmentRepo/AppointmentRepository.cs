using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.Services.EmailRepo;
using Microsoft.EntityFrameworkCore;

namespace BabbySitterAnytime.Services.AppointmentRepo
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _appDbContenxt;
        private readonly IEmailService _emailService;
        public AppointmentRepository(AppDbContext appDbContenxt, IEmailService emailService)
        {
            _appDbContenxt = appDbContenxt;
            _emailService = emailService;
        }
        public async Task<Appointment> AppointmentDetails(Guid id)
        {
            return await _appDbContenxt.Appointments.FindAsync(id);
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            _appDbContenxt.Appointments.Add(appointment);
            await _appDbContenxt.SaveChangesAsync();

            // Re-fetch the appointment with related data
            appointment = await _appDbContenxt.Appointments
                .Include(a => a.Babysitter)
                .Include(a => a.Client)
                .FirstOrDefaultAsync(a => a.Id == appointment.Id);

            await NotifyAppointmentDetails(appointment, true);
        }

        public async Task EditAppointment(Appointment appointment)
        {
            try
            {
                _appDbContenxt.Entry(appointment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _appDbContenxt.SaveChangesAsync();

                // Re-fetch the appointment with related data
                appointment = _appDbContenxt.Appointments
                    .Include(a => a.Babysitter)
                    .Include(a => a.Client)
                    .FirstOrDefault(a => a.Id == appointment.Id);

                await NotifyAppointmentDetails(appointment, false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<Appointment>> GetAppointmentsForBabysitter(Guid babySitterId)
        {
            var appointments = _appDbContenxt.Appointments.Where(a => a.BabySitterId == babySitterId)
                .ToList();
            return appointments;
        }
        public async Task<List<Appointment>> GetAppointmentsForCustomer(Guid clientId)
        {
            var appointments = _appDbContenxt.Appointments.Where(a => a.ClientId == clientId)
                .ToList();
            return appointments;
        }

        private async Task NotifyAppointmentDetails(Appointment appointment, bool isNewAppointment)
        {
            var babysitterEmail = appointment.Babysitter.Email; // Assuming Email property exists
            var clientEmail = appointment.Client.Email; // Assuming Email property exists
            var subject = isNewAppointment ? "New Appointment Created" : "Appointment Updated";
            var body = $@"
Hello,

An appointment has been {(isNewAppointment ? "created" : "updated")} with the following details:

- Starting Time: {appointment.StartingTime.ToLocalTime()}
- Ending Time: {appointment.EndingTime.ToLocalTime()}
- Status: {appointment.AppointmentStatus}

Thank you.
            ";

            await _emailService.SendEmailAsync(babysitterEmail, subject, body);
            await _emailService.SendEmailAsync(clientEmail, subject, body);
        }
    }
}
