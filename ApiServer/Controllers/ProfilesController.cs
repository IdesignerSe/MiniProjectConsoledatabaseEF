using ApiServer.Data;
using ApiServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProfilesController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/profiles
        [HttpGet]
        public IActionResult GetProfiles()
        {
            var profiles = _db.Profiles
                .Include(p => p.Student)
                .ToList();

            return Ok(profiles);
        }

        // GET: api/profiles/student/1
        [HttpGet("student/{studentId}")]
        public IActionResult GetProfileByStudent(int studentId)
        {
            var profile = _db.Profiles
                .Include(p => p.Student)
                .FirstOrDefault(p => p.StudentId == studentId);

            if (profile == null)
                return NotFound("Profile not found");

            return Ok(profile);
        }

        // POST: api/profiles
        [HttpPost]
        public IActionResult CreateProfile([FromBody] StudentProfile profile)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Profiles.Add(profile);
            _db.SaveChanges();

            return Ok(profile);
        }

        // SEED: api/profiles/seed
        [HttpGet("seed")]
        public IActionResult Seed()
        {
            if (!_db.Students.Any())
                return BadRequest("Seed students first");

            var student = _db.Students.First();

            var profile = new StudentProfile
            {
                Address = "Stockholm, Sweden",
                Phone = "070-1234567",
                StudentId = student.Id
            };

            _db.Profiles.Add(profile);
            _db.SaveChanges();

            return Ok("Profile seeded");
        }
    }
}