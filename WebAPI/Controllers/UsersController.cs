using Business.Abstracts;
using Business.Dtos.User.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await _userService.AddAsync(createUserRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.UpdateAsync(updateUserRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid userId)
        {
            var result = await _userService.DeleteAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _userService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid userId)
        {
            var result = await _userService.GetByIdAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetUserByMail")]
        public async Task<IActionResult> GetUserByMailAsync([FromQuery] string email)
        {
            var result = await _userService.GetUserByMailAsync(email);
            return Ok(result);
        }
    }
}
