using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Comment.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCommentRequest createCommentRequest)
        {
            var result = await _commentService.AddAsync(createCommentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCommentRequest updateCommentRequest)
        {
            var result = await _commentService.UpdateAsync(updateCommentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid commentId)
        {
            var result = await _commentService.DeleteAsync(commentId);
            return Ok(result);
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _commentService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid commentId)
        {
            var result = await _commentService.GetByIdAsync(commentId);
            return Ok(result);
        }
    }
}
