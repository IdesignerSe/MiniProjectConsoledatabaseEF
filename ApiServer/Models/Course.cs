using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}