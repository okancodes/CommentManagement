using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        IAssignmentService _assignmentService;
        public AssignmentsController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateAssignmentRequest createAssignmentRequest)
        {
            var result = await _assignmentService.AddAsync(createAssignmentRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAssignmentRequest updateAssignmentRequest)
        {
            var result = await _assignmentService.UpdateAsync(updateAssignmentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid assignmentId)
        {
            var result = await _assignmentService.DeleteAsync(assignmentId);
            return Ok(result);
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _assignmentService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid operationClaimId)
        {
            var result = await _assignmentService.GetByIdAsync(operationClaimId);
            return Ok(result);
        }
    }
}
