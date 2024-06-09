using BabbySitterAnytime.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace BabbySitterAnytime.Services.AreaRepo
{
    public class AreaRepository : IAreaRepository
    {
        private AppDbContext _appContext;
        public AreaRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<List<Area>> GetAllAreas() {
            return await _appContext.Areas.ToListAsync();
        }
    }
}
