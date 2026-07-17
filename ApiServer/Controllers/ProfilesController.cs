using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiServer.Data;
using ApiServer.Models;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfilesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/profiles
        [HttpGet]
        public async Task<IActionResult> GetProfiles()
        {
            var profiles = await _context.StudentProfiles.ToListAsync();
            return Ok(profiles);
        }

        // GET: api/profiles/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var profile = await _context.StudentProfiles.FindAsync(id);

            if (profile == null)
                return NotFound();

            return Ok(profile);
        }

        // POST: api/profiles
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] StudentProfile profile)
        {
            _context.StudentProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        // PUT: api/profiles/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] StudentProfile updatedProfile)
        {
            var profile = await _context.StudentProfiles.FindAsync(id);

            if (profile == null)
                return NotFound();

            profile.Address = updatedProfile.Address;
            profile.Phone = updatedProfile.Phone;
            profile.StudentId = updatedProfile.StudentId;

            await _context.SaveChangesAsync();

            return Ok(profile);
        }

        // DELETE: api/profiles/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.StudentProfiles.FindAsync(id);

            if (profile == null)
                return NotFound();

            _context.StudentProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
