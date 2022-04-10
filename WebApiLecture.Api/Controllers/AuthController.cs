using Microsoft.AspNetCore.Mvc;
using WebApiLecture.Domain.Models;
using WebApiLecture.Domain.Repositories.Interfaces;
using WebApiLecture.Domain.Services;

namespace WebApiLecture.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepostiory;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository userRepostiory, JwtService jwtService)
        {
            _userRepostiory = userRepostiory;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = await _userRepostiory.Login(model);

            if (response == null)
            {
                return BadRequest("Rejected");
            }

            return Ok(new { token = response });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var isSuccessful = await _userRepostiory.Register(model);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet("get-new-token/{token}")]
        public IActionResult GetNewToken(string token)
        {
            var newToken = _jwtService.GetNewToken(token);

            if (newToken == null)
            {
                return BadRequest();
            }

            return Ok(new { newToken });
        }
    }
}
