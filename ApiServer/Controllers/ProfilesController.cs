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
            var profiles = await _context.Profiles.ToListAsync();
            return Ok(profiles);
        }

        // POST: api/profiles
        [HttpPost]
        public async Task<IActionResult> CreateProfile([FromBody] Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfiles), new { id = profile.Id }, profile);
        }
    }
}