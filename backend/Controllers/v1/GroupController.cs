using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/group/")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGroupAsync([FromBody] Group group)
        {
            var result = await _groupService.AddAsync(group);

            if (result.Success)
                return StatusCode(201);
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupsAsync()
        {
            var groups = await _groupService.GetAllAsync();
            if (groups == null || groups.Count == 0)
            {
                return NotFound(new { Message = "Groups not found." });
            }

            return Ok(groups);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupAsync(int id)
        {
            var group = await _groupService.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound(new { Message = $"Group with ID {id} not found." });
            }

            return Ok(group);
        }

        [HttpPut("{id}")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGroupAsync(int id, [FromBody] Group newGroup)
        {
            var result = await _groupService.UpdateAsync(id, newGroup);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGroupAsync(int id)
        {
            var result = await _groupService.RemoveAsync(id);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }
    }
}
