using BabbySitterAnytime.DataBaseModels;

namespace BabbySitterAnytime.Services.AreaRepo
{
    public interface IAreaRepository
    {
        Task<List<Area>> GetAllAreas();
    }
}
