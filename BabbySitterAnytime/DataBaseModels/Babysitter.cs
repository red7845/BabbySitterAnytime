﻿using System.ComponentModel.DataAnnotations;

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
        public CurriculumVitae CurriculumVitae { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
