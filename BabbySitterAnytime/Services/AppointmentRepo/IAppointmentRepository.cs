using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.AppointmentRepo
{
    public interface IAppointmentRepository
    {
        Task CreateAppointment(Appointment appointment);
        Task EditAppointment(Appointment appointment);
        Task<Appointment> AppointmentDetails(Guid id);
        Task<List<Appointment>> GetAppointmentsForBabysitter(Guid babySitterId);
        Task<List<Appointment>> GetAppointmentsForCustomer(Guid clientId);
    }
}
