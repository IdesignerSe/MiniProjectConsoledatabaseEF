using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiServer.Data;
using ApiServer.Models;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/enrollments
        [HttpGet]
        public async Task<IActionResult> GetEnrollments()
        {
            var enrollments = await _context.Enrollments.ToListAsync();
            return Ok(enrollments);
        }

        // GET: api/enrollments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }

        // POST: api/enrollments
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] Enrollment enrollment)
        {
            enrollment.EnrolledAt = DateTime.UtcNow;

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id }, enrollment);
        }

        // PUT: api/enrollments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment(int id, [FromBody] Enrollment updatedEnrollment)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            enrollment.StudentId = updatedEnrollment.StudentId;
            enrollment.CourseId = updatedEnrollment.CourseId;
            enrollment.EnrolledAt = updatedEnrollment.EnrolledAt;

            await _context.SaveChangesAsync();

            return Ok(enrollment);
        }

        // DELETE: api/enrollments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
                return NotFound();

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}