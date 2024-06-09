using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels.AppointmentViewModels;
using BabbySitterAnytime.Services.AppointmentRepo;
using BabbySitterAnytime.Services.BabysitterRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Customer,BabySitter")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointDetailsDataViewModel>> GetAppointmentDetails(Guid id)
        {
            var appointment = await _appointmentRepository.AppointmentDetails(id);
            if (appointment == null)
            {
                return NotFound();
            }
            var appointmentViewModel = new AppointDetailsDataViewModel
            {
                BabysitterId = appointment.BabySitterId, 
                ClientId = appointment.ClientId,
                StartingTime = appointment.StartingTime,
                EndingTime = appointment.EndingTime,
                AppointmentStatus = appointment.AppointmentStatus,
                Area = appointment.Area
            };
            return appointmentViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<AppointDetailsDataViewModel>> CreateAppointment(AppointmentCreateDataViewModel appointment)
        {
            var newAppointment = new Appointment
            {
                ClientId = appointment.ClientId, 
                BabySitterId = appointment.BabysitterId, 
                StartingTime = appointment.StartingTime,
                EndingTime = appointment.EndingTime,
                Area = appointment.Area, 
                AppointmentStatus = appointment.Status
            };
            await _appointmentRepository.CreateAppointment(newAppointment);

            var appointmentViewModel = new AppointDetailsDataViewModel
            {
                ClientId = newAppointment.ClientId,
                BabysitterId = newAppointment.BabySitterId,
                StartingTime = newAppointment.StartingTime, 
                EndingTime = newAppointment.EndingTime,
                AppointmentStatus = newAppointment.AppointmentStatus,
                Area = newAppointment.Area
            };
            return Ok(appointmentViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAppointment(Guid id, AppointmentEditDataViewModel appointment)
        {
            var existingAppointment = await _appointmentRepository.AppointmentDetails(id);
            if (existingAppointment == null)
            {
                return NotFound();
            }

            existingAppointment.AppointmentStatus = appointment.AppointmentStatus;

            await _appointmentRepository.EditAppointment(existingAppointment);

            return Ok();
        }

        [HttpGet("{babysitterId}")]
        public async Task<ActionResult<List<AppointDetailsDataViewModel>>> GetAppointmentsForBabysitter(Guid babysitterId)
        {
            List<AppointDetailsDataViewModel> viewAppointments = new();
            var appointments = await _appointmentRepository.GetAppointmentsForBabysitter(babysitterId);
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    viewAppointments.Add(new AppointDetailsDataViewModel
                    {
                        Id = appointment.Id,
                        BabysitterId = appointment.BabySitterId, 
                        ClientId = appointment.ClientId,
                        AppointmentStatus = appointment.AppointmentStatus,
                        StartingTime = appointment.StartingTime,
                        EndingTime = appointment.EndingTime,
                        Area = appointment.Area
                    });
                }
            }
            return viewAppointments;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<List<AppointDetailsDataViewModel>>> GetAppointmentsForCustomer(Guid customerId)
        {
            List<AppointDetailsDataViewModel> viewAppointments = new();
            var appointments = await _appointmentRepository.GetAppointmentsForCustomer(customerId);
            if (appointments != null)
            {
                foreach (var appointment in appointments)
                {
                    viewAppointments.Add(new AppointDetailsDataViewModel
                    {
                        Id = appointment.Id,
                        StartingTime = appointment.StartingTime,
                        EndingTime = appointment.EndingTime,
                        AppointmentStatus = appointment.AppointmentStatus,
                        Area = appointment.Area
                    });
                }
            }
            return viewAppointments;
        }
    }
}
