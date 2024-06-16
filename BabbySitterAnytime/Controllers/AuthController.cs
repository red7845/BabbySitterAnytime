using BabbySitterAnytime.DataBaseModels;
using BabbySitterAnytime.DataViewModels.AuthViewModels;
using BabbySitterAnytime.Services.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BabbySitterAnytime.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(TokenService tokenService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var token = _tokenService.GenerateToken(user);

                return Ok(new { token, UserId = user.Id });
            }
            return BadRequest();
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var user = new User { UserName = model.UserName, Role = model.Role };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role.ToString());

                // Use the Id of the created user for the token generation.
                var token = _tokenService.GenerateTokenForRegisteredUser(user.Id, user.UserName, user.Role.ToString());

                // Return the token and the user's Id in the response.
                return Ok(new { token, UserId = user.Id });
            }
            return BadRequest();
        }

        [Authorize(Roles = "Customer,BabySitter")]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "You've been signed out successfully." });
        }
    }
}
