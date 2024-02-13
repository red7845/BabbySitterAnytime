using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels.CustomerViewModels;
using BabbySitterAnytime.Services.BabysitterRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Customer")]
    public class RatingController : ControllerBase
    {
        private readonly IBabySitterRepository _babySitterRepository;

        public RatingController(IBabySitterRepository babySitterRepository)
        {
            _babySitterRepository = babySitterRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddRating(Rating rating)
        {
           await _babySitterRepository.AddRatingForBabySitter(rating);
           return Ok(rating);
        }
    }
}
