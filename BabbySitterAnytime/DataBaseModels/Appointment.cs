using System.ComponentModel.DataAnnotations.Schema;

namespace BabbySitterAnytime.DataBaseModels
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid BabySitterId { get; set; }

        [ForeignKey("BabySitterId")]
        public virtual Babysitter Babysitter { get; set; }

        public Guid ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Customer Client { get; set; }

        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }
        public string Area { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }


    }
}
