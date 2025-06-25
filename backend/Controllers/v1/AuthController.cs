using backend.Services.Interfaces;
using backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/[controller]")] // flexible route
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> StudentLoginAsync([FromBody] LoginModel model)
        {
            var authResponse = await _authService.StudentLoginAsync(model.Username, model.Password);

            if (authResponse is null)
            {
                return StatusCode(500, new { message = "Something went wrong." });
            }

            return StatusCode(201, authResponse);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> StudentSignupAsync([FromBody] RegisterModel model)
        {
            var authResponse = await _authService.StudentSignupAsync(model.Username, model.Password, model.ConfirmPassword, model.Email, model.Birthday);

            if (authResponse is null)
            {
                return StatusCode(500, new { message = "Something went wrong." });
            }

            return StatusCode(201, authResponse);
        }
    }
}
