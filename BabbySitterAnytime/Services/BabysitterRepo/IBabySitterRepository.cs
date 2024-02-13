using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.BabysitterRepo
{
    public interface IBabySitterRepository
    {
        Task CreateProfile(Babysitter babysitter);
        Task EditProfile(Babysitter babysitter);
        Task<Babysitter> ProfileDetails(Guid id);
        Task AddRatingForBabySitter(Rating rating);
    }
}
