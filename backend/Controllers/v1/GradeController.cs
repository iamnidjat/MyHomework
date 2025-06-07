using backend.Models;
using backend.Services.Implementations;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGradeAsync([FromBody] Grade grade)
        {
            var result = await _gradeService.AddAsync(grade);

            if (result.Success)
                return StatusCode(201);
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpGet]
        public async Task<IActionResult> GetGradesAsync()
        {
            var grades = await _gradeService.GetAllAsync();
            if (grades == null || grades.Count == 0)
            {
                return NotFound(new { Message = "Grades not found." });
            }

            return Ok(grades);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeAsync(int id)
        {
            var grade = await _gradeService.GetByIdAsync(id);
            if (grade == null)
            {
                return NotFound(new { Message = $"Grade with ID {id} not found." });
            }

            return Ok(grade);
        }

        [HttpPut("{id}")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateGradeAsync(int id, [FromBody] Grade newGrade)
        {
            var result = await _gradeService.UpdateAsync(id, newGrade);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGradeAsync(int id)
        {
            var result = await _gradeService.RemoveAsync(id);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }
    }
}
