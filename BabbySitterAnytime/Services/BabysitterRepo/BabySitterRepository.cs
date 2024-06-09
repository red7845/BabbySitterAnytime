using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels;
using BabbySitterAnytime.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BabbySitterAnytime.Services.BabysitterRepo
{
    public class BabySitterRepository : IBabySitterRepository
    {
        private readonly AppDbContext _appDbContenxt;

        public BabySitterRepository(AppDbContext appDbContenxt)
        {
            _appDbContenxt = appDbContenxt;
        }

        public async Task CreateProfile(Babysitter babysitter)
        {
            _appDbContenxt.Babysitters.Add(babysitter);
            await _appDbContenxt.SaveChangesAsync();
        }

        public async Task EditProfile(Babysitter babysitter)
        {
            try
            {
                _appDbContenxt.Entry(babysitter).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _appDbContenxt.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Babysitter> ProfileDetails(Guid id)
        {
            return await _appDbContenxt.Babysitters.FindAsync(id);
        }

        public async Task AddRatingForBabySitter(RatingViewModel ratingViewModel)
        {
            Rating rating = new()
            {
                BabysitterId = ratingViewModel.BabysitterId,
                Score = ratingViewModel.Score, 
                Comment = ratingViewModel.Comment,
            };
            _appDbContenxt.Ratings.Add(rating);
            await _appDbContenxt.SaveChangesAsync();
        }

        public async Task<Babysitter> GetBabysitterByUserId(string userId)
        {
            return await _appDbContenxt.Babysitters.Where(b=>b.UserId == userId).FirstAsync();
        }

        public async Task<List<Babysitter>> GetBabysitters()
        {
            return await _appDbContenxt.Babysitters.ToListAsync();
        }

        public async Task<List<Babysitter>> GetBabysittersBySupportingArea(Guid areaId)
        {
            var babysitters = await _appDbContenxt.BabysitterArea
            .Where(ba => ba.AreaId == areaId)
            .Select(ba => ba.Babysitter)
            .ToListAsync();

            return babysitters;
        }

        public async Task<List<RatingViewModel>> GetRatingsForBabysitter(Guid babysitterId)
        {
            List<RatingViewModel> ratingViewModels = new();
            var ratings = await _appDbContenxt.Ratings.Where(r => r.BabysitterId == babysitterId).ToListAsync();
            if (ratings != null && ratings.Count() != 0)
            {
                foreach (var rating in ratings)
                {
                    var ratingViewModel = new RatingViewModel()
                    {
                        BabysitterId = rating.BabysitterId,
                        Score = rating.Score,
                        Comment = rating.Comment
                    };
                    ratingViewModels.Add(ratingViewModel);
                }
            }
            
            return ratingViewModels;
        }
    }
}
