using Microsoft.AspNetCore.Identity;

namespace BabbySitterAnytime.DataBaseModels
{
    public class User : IdentityUser
    {
        public Roles Role { get; set; } 
    }
}
