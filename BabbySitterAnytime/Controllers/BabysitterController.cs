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
    
    public class BabysitterController : ControllerBase
    {
        private readonly IBabySitterRepository _babySitterRepository;
        public BabysitterController(IBabySitterRepository babySitterRepository)
        {
            _babySitterRepository = babySitterRepository;
        }
        [Authorize(Roles = "Customer, BabySitter")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BabySitterDetailsDataViewModel>> GetProfileDetails(Guid id)
        {
            var babySitter = await _babySitterRepository.ProfileDetails(id);
            if (babySitter == null)
            {
                return NotFound();
            }

            BabySitterDetailsDataViewModel babysitterViewModel = new BabySitterDetailsDataViewModel
            {
                FirstName = babySitter.FirstName,
                LastName = babySitter.LastName,
                PhoneNumber = babySitter.PhoneNumber,
                Email = babySitter.Email,
                Address = babySitter.Address,
                PhotoUrl = babySitter.PhotoUrl,
                Score = CalculateScore(babySitter.Ratings), 
                Id = babySitter.Id,
                HourlyRate = babySitter.HourlyRate,
                CurriculumVitae = babySitter.CurriculumVitae != null ? new CVDataViewModel
                {
                    Title = babySitter.CurriculumVitae.Title,
                    Description = babySitter.CurriculumVitae.Description
                } : null
            };

            return babysitterViewModel;
        }
        [Authorize(Roles = "BabySitter")]
        [HttpPost]
        public async Task<ActionResult<BabySitterCreateDataViewModel>> CreatePofile(BabySitterCreateDataViewModel babysitter)
        {
            var newBabySitter = new Babysitter
            {
                FirstName = babysitter.FirstName,
                LastName = babysitter.LastName,
                PhoneNumber = babysitter.PhoneNumber,
                Email = babysitter.Email,
                Address = babysitter.Address,
                UserId = babysitter.UserId, 
                PhotoUrl= babysitter.PhotoUrl,
                HourlyRate = babysitter.HourlyRate,
                SupportingAreas = babysitter.AreaIds.Select(areaId => new BabysitterArea { AreaId = areaId }).ToList()
            };
            await _babySitterRepository.CreateProfile(newBabySitter);

            var babysitterViewModel = new BabySitterCreateDataViewModel
            {
                FirstName = babysitter.FirstName,
                LastName = babysitter.LastName,
                PhoneNumber = babysitter.PhoneNumber,
                Email = babysitter.Email,
                Address = babysitter.Address, 
                PhotoUrl = babysitter.PhotoUrl,
                HourlyRate = babysitter.HourlyRate
            };

            return CreatedAtAction(nameof(GetProfileDetails), new { id = newBabySitter.Id }, babysitterViewModel);
        }
        [Authorize(Roles = "BabySitter")]
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
            existingBabysitter.PhotoUrl = babySitter.PhotoUrl;
            existingBabysitter.HourlyRate = babySitter.HourlyRate;
            

            await _babySitterRepository.EditProfile(existingBabysitter);
            return Ok();
        }
        [Authorize(Roles = "BabySitter")]
        [HttpGet("{userId}")]
        public async Task<ActionResult<BabySitterDetailsDataViewModel>> GetBabysitterByUserId(string userId)
        {
            var babySitter = await _babySitterRepository.GetBabysitterByUserId(userId);
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
                Id = babySitter.Id, 
                PhotoUrl = babySitter.PhotoUrl,
                HourlyRate = babySitter.HourlyRate
            };

            return babysitterViewModel;
        }
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public async Task<ActionResult<List<BabySitterDetailsDataViewModel>>> GetBabysitters()
        {
            List<BabySitterDetailsDataViewModel> babySitterDetailsDataViewModels = new();
            var babysitters =  await _babySitterRepository.GetBabysitters();
            if (babysitters.Count == 0)
            {
                return NotFound();
            }
            foreach (var babysitter in babysitters)
            {
                var babysitterViewModel = new BabySitterDetailsDataViewModel
                {
                    FirstName = babysitter.FirstName,
                    LastName = babysitter.LastName,
                    PhoneNumber = babysitter.PhoneNumber,
                    Email = babysitter.Email,
                    Address = babysitter.Address,
                    Score = CalculateScore(babysitter.Ratings),
                    Id = babysitter.Id, 
                    PhotoUrl= babysitter.PhotoUrl,
                    HourlyRate = babysitter.HourlyRate,

                };
                babySitterDetailsDataViewModels.Add(babysitterViewModel);
            }
            return babySitterDetailsDataViewModels;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("{areaId}")]
        public async Task<ActionResult<List<BabySitterDetailsDataViewModel>>> GetBabysittersBySupportingArea(Guid areaId)
        {
            List<BabySitterDetailsDataViewModel> babySitterDetailsDataViewModels = new();
            var babysitters = await _babySitterRepository.GetBabysittersBySupportingArea(areaId);
            if (babysitters.Count == 0)
            {
                return NotFound();
            }
            foreach (var babysitter in babysitters)
            {
                var babysitterViewModel = new BabySitterDetailsDataViewModel
                {
                    FirstName = babysitter.FirstName,
                    LastName = babysitter.LastName,
                    PhoneNumber = babysitter.PhoneNumber,
                    Email = babysitter.Email,
                    Address = babysitter.Address,
                    Score = CalculateScore(babysitter.Ratings),
                    Id = babysitter.Id,
                    PhotoUrl = babysitter.PhotoUrl,
                    HourlyRate = babysitter.HourlyRate

                };
                babySitterDetailsDataViewModels.Add(babysitterViewModel);
            }
            return babySitterDetailsDataViewModels;
        }

        private double CalculateScore(List<Rating> ratings)
        {
            List<int> scores = new();
            if (ratings != null && ratings.Count!= 0)
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