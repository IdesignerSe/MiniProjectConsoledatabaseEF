using System.ComponentModel.DataAnnotations;

namespace ApiServer.Models
{
    public class StudentProfile
    {
        public int Id { get; set; }   // PK

        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int StudentId { get; set; }   // FK
        public Student? Student { get; set; }
    }
}
