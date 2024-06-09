using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels.BabySitterViewModels;
using BabbySitterAnytime.Services.CVRepo;
using Microsoft.AspNetCore.Authorization;

namespace BabbySitterAnytime.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CurriculumVitaesController : ControllerBase
    {
        private readonly ICVRepository _cvRepository;

        public CurriculumVitaesController(ICVRepository cvRepository)
        {
            _cvRepository = cvRepository;
        }

        // GET: api/CurriculumVitaes/{babySitterId}
        [Authorize(Roles = "Customer,BabySitter")]
        [HttpGet("{babySitterId}")]
        public async Task<ActionResult<CVDataViewModel>> GetCurriculumVitae(Guid babySitterId)
        {
            var cv = await _cvRepository.GetCVForBabySitter(babySitterId);
            if (cv == null)
            {
                return NotFound();
            }

            var cvModel = new CVDataViewModel
            {
                Title = cv.Title,
                Description = cv.Description
            };

            return cvModel;
        }

        // POST: api/CurriculumVitaes
        [Authorize(Roles = "BabySitter")]
        [HttpPost]
        public async Task<ActionResult<CVDataViewModel>> PostCurriculumVitae(CVDataViewModel cvModel)
        {
            var newCv = new CurriculumVitae
            {
                Id = Guid.NewGuid(), // Assuming IDs are generated on the server side.
                Title = cvModel.Title,
                Description = cvModel.Description,
                BabySitterId = cvModel.BabysitterId // You would need to set this based on your logic.
            };

            await _cvRepository.CreateCV(newCv);

            return CreatedAtAction(nameof(GetCurriculumVitae), new { babySitterId = newCv.BabySitterId }, cvModel);
        }

        // PUT: api/CurriculumVitaes/{id}
        [Authorize(Roles = "BabySitter")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculumVitae(Guid id, CVDataViewModel cvModel)
        {
            var existingCv = await _cvRepository.GetCVForBabySitter(id);
            if (existingCv == null)
            {
                return NotFound();
            }

            existingCv.Title = cvModel.Title;
            existingCv.Description = cvModel.Description;

            await _cvRepository.EditCV(existingCv);

            return NoContent();
        }

        // Additional methods for Delete and Details can be implemented following similar patterns.
    }
}