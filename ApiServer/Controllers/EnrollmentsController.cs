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

        // POST: api/enrollments
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] Enrollment enrollment)
        {
            enrollment.EnrolledAt = DateTime.UtcNow;

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrollments), new { id = enrollment.Id }, enrollment);
        }
    }
}