using Microsoft.EntityFrameworkCore;
using ApiServer.Models;

namespace ApiServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice", Age = 20 },
                new Student { Id = 2, Name = "Bob", Age = 22 },
                new Student { Id = 3, Name = "Charlie", Age = 19 },
                new Student { Id = 4, Name = "Diana", Age = 21 },
                new Student { Id = 5, Name = "Edward", Age = 23 },
                new Student { Id = 6, Name = "Fiona", Age = 20 },
                new Student { Id = 7, Name = "George", Age = 24 },
                new Student { Id = 8, Name = "Hannah", Age = 18 },
                new Student { Id = 9, Name = "Ian", Age = 22 },
                new Student { Id = 10, Name = "Julia", Age = 19 }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Mathematics", Credits = 3 },
                new Course { Id = 2, Title = "Physics", Credits = 4 },
                new Course { Id = 3, Title = "Chemistry", Credits = 3 },
                new Course { Id = 4, Title = "Biology", Credits = 3 },
                new Course { Id = 5, Title = "Programming 1", Credits = 5 },
                new Course { Id = 6, Title = "Programming 2", Credits = 5 },
                new Course { Id = 7, Title = "History", Credits = 2 },
                new Course { Id = 8, Title = "Geography", Credits = 2 },
                new Course { Id = 9, Title = "Art", Credits = 1 },
                new Course { Id = 10, Title = "Music", Credits = 1 }
            );

            // Student Profiles
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile { Id = 1, StudentId = 1, Address = "Street 1", Phone = "555-001" },
                new StudentProfile { Id = 2, StudentId = 2, Address = "Street 2", Phone = "555-002" },
                new StudentProfile { Id = 3, StudentId = 3, Address = "Street 3", Phone = "555-003" },
                new StudentProfile { Id = 4, StudentId = 4, Address = "Street 4", Phone = "555-004" },
                new StudentProfile { Id = 5, StudentId = 5, Address = "Street 5", Phone = "555-005" },
                new StudentProfile { Id = 6, StudentId = 6, Address = "Street 6", Phone = "555-006" },
                new StudentProfile { Id = 7, StudentId = 7, Address = "Street 7", Phone = "555-007" },
                new StudentProfile { Id = 8, StudentId = 8, Address = "Street 8", Phone = "555-008" },
                new StudentProfile { Id = 9, StudentId = 9, Address = "Street 9", Phone = "555-009" },
                new StudentProfile { Id = 10, StudentId = 10, Address = "Street 10", Phone = "555-010" }
            );

            // Enrollments (20) — FIXED DATE (NO UtcNow)
            var fixedDate = new DateTime(2024, 01, 01);

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrolledAt = fixedDate },
                new Enrollment { Id = 2, StudentId = 1, CourseId = 5, EnrolledAt = fixedDate },
                new Enrollment { Id = 3, StudentId = 2, CourseId = 2, EnrolledAt = fixedDate },
                new Enrollment { Id = 4, StudentId = 2, CourseId = 6, EnrolledAt = fixedDate },
                new Enrollment { Id = 5, StudentId = 3, CourseId = 3, EnrolledAt = fixedDate },
                new Enrollment { Id = 6, StudentId = 3, CourseId = 7, EnrolledAt = fixedDate },
                new Enrollment { Id = 7, StudentId = 4, CourseId = 4, EnrolledAt = fixedDate },
                new Enrollment { Id = 8, StudentId = 4, CourseId = 8, EnrolledAt = fixedDate },
                new Enrollment { Id = 9, StudentId = 5, CourseId = 5, EnrolledAt = fixedDate },
                new Enrollment { Id = 10, StudentId = 5, CourseId = 9, EnrolledAt = fixedDate },
                new Enrollment { Id = 11, StudentId = 6, CourseId = 6, EnrolledAt = fixedDate },
                new Enrollment { Id = 12, StudentId = 6, CourseId = 10, EnrolledAt = fixedDate },
                new Enrollment { Id = 13, StudentId = 7, CourseId = 7, EnrolledAt = fixedDate },
                new Enrollment { Id = 14, StudentId = 7, CourseId = 1, EnrolledAt = fixedDate },
                new Enrollment { Id = 15, StudentId = 8, CourseId = 8, EnrolledAt = fixedDate },
                new Enrollment { Id = 16, StudentId = 8, CourseId = 2, EnrolledAt = fixedDate },
                new Enrollment { Id = 17, StudentId = 9, CourseId = 9, EnrolledAt = fixedDate },
                new Enrollment { Id = 18, StudentId = 9, CourseId = 3, EnrolledAt = fixedDate },
                new Enrollment { Id = 19, StudentId = 10, CourseId = 10, EnrolledAt = fixedDate },
                new Enrollment { Id = 20, StudentId = 10, CourseId = 4, EnrolledAt = fixedDate }
            );
        }
    }
}