using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.AppointmentRepo
{
    public interface IAppointmentRepository
    {
        Task CreateAppointment(Appointment appointment);
        Task EditAppointment(Guid babysiiterId, Guid clientId, Appointment appointment);
        Task<Appointment> AppointmentDetails(Guid babysiiterId, Guid clientId);
        Task<List<Appointment>> GetAppointmentsForBabysitter(Guid babySitterId);
        Task<List<Appointment>> GetAppointmentsForCustomer(Guid clientId);
    }
}
