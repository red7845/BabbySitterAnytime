using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels.BabySitterViewModels;
using BabbySitterAnytime.Services.BabysitterRepo;
using BabbySitterAnytime.Services.ClientRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Babysitter")]
    public class BabysitterController : ControllerBase
    {
        private readonly IBabySitterRepository _babySitterRepository;
        public BabysitterController(IBabySitterRepository babySitterRepository)
        {
            _babySitterRepository = babySitterRepository;
        }
        [Authorize(Roles = "CUSTOMER, BABYSITTER")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BabySitterDetailsDataViewModel>> GetProfileDetails(Guid id)
        {
            var babySitter = await _babySitterRepository.ProfileDetails(id);
            if (babySitter == null)
            {
                return NotFound();
            }

            var babysitterViewModel = new BabySitterDetailsDataViewModel
            {
                FirstName = babySitter.FirstName,
                LastName = babySitter.LastName,
                PhoneNumber = babySitter.PhoneNumber,
                Email = babySitter.Email,
                Address = babySitter.Address,
                Score = CalculateScore(babySitter.Ratings), 
                Id = babySitter.Id
            };

            return babysitterViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<BabySitterCreateDataViewModel>> CreatePofile(BabySitterCreateDataViewModel babysitter)
        {
            var newBabySitter = new Babysitter
            {
                FirstName = babysitter.FirstName,
                LastName = babysitter.LastName,
                PhoneNumber = babysitter.PhoneNumber,
                Email = babysitter.Email,
                Address = babysitter.Address
            };
            await _babySitterRepository.CreateProfile(newBabySitter);

            var babysitterViewModel = new BabySitterCreateDataViewModel
            {
                Id = newBabySitter.Id,
                FirstName = babysitter.FirstName,
                LastName = babysitter.LastName,
                PhoneNumber = babysitter.PhoneNumber,
                Email = babysitter.Email,
                Address = babysitter.Address
            };

            return CreatedAtAction(nameof(GetProfileDetails), new { id = newBabySitter.Id }, babysitterViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProfile(Guid id, BabySitterEditViewModels babySitter)
        {
            var existingBabysitter = await _babySitterRepository.ProfileDetails(id);

            if (existingBabysitter == null)
            {
                return NotFound();
            }

            existingBabysitter.FirstName = babySitter.FirstName;
            existingBabysitter.LastName = babySitter.LastName;
            existingBabysitter.PhoneNumber = babySitter.PhoneNumber;
            existingBabysitter.Address = babySitter.Address;
            existingBabysitter.Email = babySitter.Email;

            await _babySitterRepository.EditProfile(existingBabysitter);
            return Ok();
        }

        private double CalculateScore(List<Rating> ratings)
        {
            List<int> scores = new();
            if (ratings != null)
            {
                foreach (Rating rating in ratings)
                {
                    scores.Add(rating.Score);
                }
                return scores.Average();
            }
            return 0;
        }
    }
}
