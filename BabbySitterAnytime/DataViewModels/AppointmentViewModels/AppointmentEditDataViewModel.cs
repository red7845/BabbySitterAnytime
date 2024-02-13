using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.DataViewModels.AppointmentViewModels
{
    public class AppointmentEditDataViewModel
    {
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
