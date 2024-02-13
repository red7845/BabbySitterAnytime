using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.DataViewModels.AuthViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
