using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels;
using BabbySitterAnytime.DataViewModels.CustomerViewModels;
using BabbySitterAnytime.Services.BabysitterRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RatingController : ControllerBase
    {
        private readonly IBabySitterRepository _babySitterRepository;

        public RatingController(IBabySitterRepository babySitterRepository)
        {
            _babySitterRepository = babySitterRepository;
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<ActionResult> AddRating(RatingViewModel ratingViewModel)
        {
            await _babySitterRepository.AddRatingForBabySitter(ratingViewModel);
            return Ok(ratingViewModel);
        }

        [Authorize(Roles = "Customer,BabySitter")]
        [HttpGet("{babysitterId}")]
        public async Task<ActionResult<List<RatingViewModel>>> GetRatingsForBabysitter(Guid babysitterId)
        {
            var ratings = await _babySitterRepository.GetRatingsForBabysitter(babysitterId);
            return Ok(ratings);
        }
    }
}
