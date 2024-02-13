using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.AppointmentRepo
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _appDbContenxt;

        public AppointmentRepository(AppDbContext appDbContenxt)
        {
            _appDbContenxt = appDbContenxt;
        }
        public async Task<Appointment> AppointmentDetails(Guid babysiiterId, Guid clientId)
        {
            return await _appDbContenxt.Appointments.FindAsync(babysiiterId, clientId);
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            _appDbContenxt.Appointments.Add(appointment);
            await _appDbContenxt.SaveChangesAsync();
        }

        public async Task EditAppointment(Guid babysiiterId, Guid clientId, Appointment appointment)
        {
            try
            {
                _appDbContenxt.Entry(appointment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _appDbContenxt.SaveChangesAsync();
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
    }
}
