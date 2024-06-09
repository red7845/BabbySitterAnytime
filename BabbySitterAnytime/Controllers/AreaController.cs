using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels;
using BabbySitterAnytime.Services.AreaRepo;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AreaController : ControllerBase
    {
        private IAreaRepository _areaRepository;
        public AreaController(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<AreaViewModel>>> GetAllAreas()
        {
            var areas = await _areaRepository.GetAllAreas();
            List<AreaViewModel> areaViewModels = [];
            foreach (var area in areas)
            {
                areaViewModels.Add(new AreaViewModel
                {
                    Id = area.Id,
                    Name = area.Name,
                });
            }
            return areaViewModels;
        } 
    }
}
