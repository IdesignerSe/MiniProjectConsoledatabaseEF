using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=MiniProjectConsoledatabaseEF;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Profile)
                .WithOne(p => p.Student)
                .HasForeignKey<StudentProfile>(p => p.StudentId);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new Student { Id = 2, Name = "Bob", Email = "bob@example.com" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "C# Basics", Credits = 5 },
                new Course { Id = 2, Title = "Entity Framework Core", Credits = 7 }
            );

            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile { StudentId = 1, Address = "Main Street 1" },
                new StudentProfile { StudentId = 2, Address = "Second Street 2" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { StudentId = 1, CourseId = 1, Grade = "A" },
                new Enrollment { StudentId = 1, CourseId = 2, Grade = "B" },
                new Enrollment { StudentId = 2, CourseId = 2, Grade = "A" }
            );
        }
    }
}
