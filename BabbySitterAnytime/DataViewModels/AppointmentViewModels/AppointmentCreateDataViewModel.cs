using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.DataViewModels.AppointmentViewModels
{
    public class AppointmentCreateDataViewModel
    {
        public Guid BabysitterId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string Area { get; set; }
        public AppointmentStatus Status { get; set; }

    }
}
