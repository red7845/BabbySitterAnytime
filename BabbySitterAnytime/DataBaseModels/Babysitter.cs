using System.ComponentModel.DataAnnotations;

namespace BabbySitterAnytime.DataBaseModels
{
    public class Babysitter
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public int HourlyRate { get; set; }
        public virtual CurriculumVitae CurriculumVitae { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<BabysitterArea> SupportingAreas { get; set; }  
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
