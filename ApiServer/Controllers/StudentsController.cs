using ApiServer.Data;
using ApiServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _db.Students
                .Include(s => s.Profile)
                .ToList();

            return Ok(students);
        }

        // Endpoint de prueba
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API funciona");
        }
    }
}
