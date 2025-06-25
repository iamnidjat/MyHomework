using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/manage-profile")]
    [ApiController]
    public class ManageProfileController : ControllerBase
    {
        private readonly IManageProfileService _manageProfileService;
        public ManageProfileController(IManageProfileService manageProfileService)
        {
            _manageProfileService = manageProfileService;
        }

        [HttpPut("students/{id}")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudentProfileAsync(int id, StudentProfile updatedProfile)
        {
            var result = await _manageProfileService.UpdateStudentProfileAsync(id, updatedProfile);
            
            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpPut("teachers/{id}")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTeacherProfileAsync(int id, TeacherProfile updatedProfile)
        {
            var result = await _manageProfileService.UpdateTeacherProfileAsync(id, updatedProfile);
            
            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpPut("{id}/username")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUsernameAsync(int id, string newUsername, string userType)
        {
            var result = await _manageProfileService.UpdateUsernameAsync(id, newUsername, userType);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpPut("{id}/email")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmailAsync(int id, string newEmail, string userType)
        {
            var result = await _manageProfileService.UpdateEmailAsync(id, newEmail, userType);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }
    }
}
