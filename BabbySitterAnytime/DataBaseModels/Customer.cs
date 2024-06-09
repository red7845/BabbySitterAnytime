using System.ComponentModel.DataAnnotations;

namespace BabbySitterAnytime.DataBaseModels
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
