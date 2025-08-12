using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncementAsync([FromBody] Announcement announcement)
        {
            var result = await _announcementService.AddAsync(announcement);

            if (result.Success)
                return StatusCode(201);
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpGet]
        public async Task<IActionResult> GetAnnouncementsAsync()
        {
            var announcements = await _announcementService.GetAllAsync();
            if (announcements == null || announcements.Count == 0)
            {
                return NotFound(new { Message = "Announcements not found." });
            }

            return Ok(announcements);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementAsync(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            if (announcement == null)
            {
                return NotFound(new { Message = $"Announcements with ID {id} not found." });
            }

            return Ok(announcement);
        }

        [HttpPut("{id}")]
        //[HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAnnouncementAsync(int id, [FromBody] Announcement announcement)
        {
            var result = await _announcementService.UpdateAsync(id, announcement);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAnnouncementsAsync(int id)
        {
            var result = await _announcementService.RemoveAsync(id);

            if (result.Success)
                return NoContent();
            else
                return StatusCode(500, new { message = result.ErrorMessage });
        }
    }
}
