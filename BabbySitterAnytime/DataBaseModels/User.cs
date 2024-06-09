using Microsoft.AspNetCore.Identity;

namespace BabbySitterAnytime.DataBaseModels
{
    public class User : IdentityUser
    {
        public Roles Role { get; set; }

        public virtual Babysitter Babysitter { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
