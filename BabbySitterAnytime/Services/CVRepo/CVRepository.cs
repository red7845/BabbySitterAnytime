using BabbySitterAnytime.DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace BabbySitterAnytime.Services.CVRepo
{
    public class CVRepository : ICVRepository
    {
        private readonly AppDbContext _appDbContext;

        public CVRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task CreateCV(CurriculumVitae curriculumVitae)
        {
            _appDbContext.CurriculumVitaes.Add(curriculumVitae);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task EditCV(CurriculumVitae curriculumVitae)
        {
            _appDbContext.Entry(curriculumVitae).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<CurriculumVitae> GetCVForBabySitter(Guid babysitterId)
        {
            return await _appDbContext.CurriculumVitaes.Where(cv => cv.BabySitterId == babysitterId).FirstOrDefaultAsync();
        }
    }
}
