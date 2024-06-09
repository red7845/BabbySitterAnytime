using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.CVRepo
{
    public interface ICVRepository
    {
        Task<CurriculumVitae> GetCVForBabySitter(Guid babysitterId);
        Task CreateCV(CurriculumVitae curriculumVitae);
        Task EditCV(CurriculumVitae curriculumVitae);
    }
}
