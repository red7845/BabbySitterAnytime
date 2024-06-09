using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels;

namespace BabbySitterAnytime.Services.BabysitterRepo
{
    public interface IBabySitterRepository
    {
        Task CreateProfile(Babysitter babysitter);
        Task EditProfile(Babysitter babysitter);
        Task<Babysitter> ProfileDetails(Guid id);
        Task<Babysitter> GetBabysitterByUserId(string userId);
        Task AddRatingForBabySitter(RatingViewModel rating);
        Task<List<RatingViewModel>> GetRatingsForBabysitter(Guid babysitterId);
        Task<List<Babysitter>> GetBabysitters();
        Task<List<Babysitter>> GetBabysittersBySupportingArea(Guid areaId);
    }
}
