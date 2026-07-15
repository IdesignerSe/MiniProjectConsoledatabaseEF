using ApiServer.Data;
using ApiServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CoursesController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/courses
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = _db.Courses
                .Include(c => c.Enrollments)
                .ToList();

            return Ok(courses);
        }

        // GET: api/courses/5
        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var course = _db.Courses
                .Include(c => c.Enrollments)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound("Course not found");

            return Ok(course);
        }

        // POST: api/courses
        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Courses.Add(course);
            _db.SaveChanges();

            return Ok(course);
        }

        // SEED: api/courses/seed
        [HttpGet("seed")]
        public IActionResult Seed()
        {
            var list = new List<Course>
            {
                new Course { Title = "Mathematics 101", Credits = 5 },
                new Course { Title = "Programming in C#", Credits = 7 },
                new Course { Title = "Database Fundamentals", Credits = 6 }
            };

            _db.Courses.AddRange(list);
            _db.SaveChanges();

            return Ok("Courses seeded");
        }
    }
}