using ApiServer.Data;
using ApiServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EnrollmentsController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/enrollments
        [HttpGet]
        public IActionResult GetAll()
        {
            var enrollments = _db.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .ToList();

            return Ok(enrollments);
        }

        // GET: api/enrollments/student/1
        [HttpGet("student/{studentId}")]
        public IActionResult GetByStudent(int studentId)
        {
            var enrollments = _db.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToList();

            return Ok(enrollments);
        }

        // GET: api/enrollments/course/1
        [HttpGet("course/{courseId}")]
        public IActionResult GetByCourse(int courseId)
        {
            var enrollments = _db.Enrollments
                .Include(e => e.Student)
                .Where(e => e.CourseId == courseId)
                .ToList();

            return Ok(enrollments);
        }

        // POST: api/enrollments
        [HttpPost]
        public IActionResult Create([FromBody] Enrollment enrollment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Enrollments.Add(enrollment);
            _db.SaveChanges();

            return Ok(enrollment);
        }

        // SEED: api/enrollments/seed
        [HttpGet("seed")]
        public IActionResult Seed()
        {
            if (!_db.Students.Any() || !_db.Courses.Any())
                return BadRequest("Seed students and courses first");

            var e1 = new Enrollment
            {
                StudentId = _db.Students.First().Id,
                CourseId = _db.Courses.First().Id
            };

            _db.Enrollments.Add(e1);
            _db.SaveChanges();

            return Ok("Enrollments seeded");
        }
    }
}