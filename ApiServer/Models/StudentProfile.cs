using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class StudentProfile
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        public Student? Student { get; set; }
    }
}