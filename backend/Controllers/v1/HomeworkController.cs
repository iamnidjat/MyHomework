using backend.Models;
using backend.Services.Interfaces;
using backend.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        public HomeworkController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHomeworkAsync([FromBody] Homework homework)
        {
            var result = await _homeworkService.AddAsync(homework);

            if (result.Success)
                return StatusCode(201);
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpGet]
        public async Task<IActionResult> GetHomeworksAsync()
        {
            var homeworks = await _homeworkService.GetAllAsync();
            if (homeworks == null || homeworks.Count == 0)
            {
                return NotFound(new { Message = "Homeworks not found." });
            }

            return Ok(homeworks);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetHomeworkAsync(int id)
        {
            var homework = await _homeworkService.GetByIdAsync(id);
            if (homework == null)
            {
                return NotFound(new { Message = $"Homework with ID {id} not found." });
            }

            return Ok(homework);
        }

        [HttpPut("{id}")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateHomeworkAsync(int id, [FromBody] Homework newHomework)
        {
            var result = await _homeworkService.UpdateAsync(id, newHomework);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveHomeworkAsync(int id)
        {
            var result = await _homeworkService.RemoveAsync(id);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }
    }
}
