using System.ComponentModel.DataAnnotations.Schema;

namespace ApiServer.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        // Relación con Student
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        // Relación con Course
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        // Fecha de inscripción
        public DateTime EnrolledAt { get; set; } = DateTime.Now;
    }
}
