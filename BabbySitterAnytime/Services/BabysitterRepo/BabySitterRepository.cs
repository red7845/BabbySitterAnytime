using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.Migrations;

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

        public async Task AddRatingForBabySitter(Rating rating)
        {
            _appDbContenxt.Ratings.Add(rating);
            await _appDbContenxt.SaveChangesAsync();
        }
    }
}
