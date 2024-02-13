namespace BabbySitterAnytime.DataBaseModels
{
    public class Appointment
    {
        public Guid BabySitterId { get; set; }
        public Babysitter Babysitter { get; set; }

        public Guid ClientId { get; set; }
        public Customer Client { get; set; }

        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string Area { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }


    }
}
