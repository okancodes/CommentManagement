using Business.Abstracts;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var userToLogin = await _authService.Login(loginRequest);
            var result = _authService.CreateAccesToken(userToLogin);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            var userToRegister = await _authService.Register(registerRequest);
            var result = _authService.CreateAccesToken(userToRegister);
            return Ok(result);
        }
    }
}