using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.DataViewModels.AppointmentViewModels
{
    public class AppointDetailsDataViewModel
    {
        public Guid Id { get; set; }
        public Guid BabysitterId { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string Area { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
