using System;
using ConsoleApp.Data;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();

            while (true)
            {
                Console.WriteLine("\n=== EF Core CRUD Menu ===");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Courses");
                Console.WriteLine("3. Student Profiles");
                Console.WriteLine("4. Enrollments");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StudentMenu(db);
                        break;
                    case "2":
                        CourseMenu(db);
                        break;
                    case "3":
                        ProfileMenu(db);
                        break;
                    case "4":
                        EnrollmentMenu(db);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ============================
        // STUDENT CRUD
        // ============================

        static void StudentMenu(AppDbContext db)
        {
            Console.WriteLine("\n=== Student Menu ===");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.Write("Choose: ");

            var c = Console.ReadLine();

            switch (c)
            {
                case "1": CreateStudent(db); break;
                case "2": ReadStudents(db); break;
                case "3": UpdateStudent(db); break;
                case "4": DeleteStudent(db); break;
            }
        }

        static void CreateStudent(AppDbContext db)
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            var s = new Student { Name = name ?? "", Email = email ?? "" };
            db.Students.Add(s);
            db.SaveChanges();

            Console.WriteLine("Student created.");
        }

        static void ReadStudents(AppDbContext db)
        {
            Console.WriteLine("\n=== Students ===");
            foreach (var s in db.Students.Include(s => s.Profile))
            {
                Console.WriteLine($"{s.Id}: {s.Name} - {s.Email} | Address: {s.Profile?.Address}");
            }
        }

        static void UpdateStudent(AppDbContext db)
        {
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var s = db.Students.Find(id);
            if (s == null) { Console.WriteLine("Not found."); return; }

            Console.Write("New name: ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) s.Name = name;

            Console.Write("New email: ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) s.Email = email;

            db.SaveChanges();
            Console.WriteLine("Updated.");
        }

        static void DeleteStudent(AppDbContext db)
        {
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var s = db.Students.Find(id);
            if (s == null) { Console.WriteLine("Not found."); return; }

            db.Students.Remove(s);
            db.SaveChanges();
            Console.WriteLine("Deleted.");
        }

        // ============================
        // COURSE CRUD
        // ============================

        static void CourseMenu(AppDbContext db)
        {
            Console.WriteLine("\n=== Course Menu ===");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.Write("Choose: ");

            var c = Console.ReadLine();

            switch (c)
            {
                case "1": CreateCourse(db); break;
                case "2": ReadCourses(db); break;
                case "3": UpdateCourse(db); break;
                case "4": DeleteCourse(db); break;
            }
        }

        static void CreateCourse(AppDbContext db)
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();

            Console.Write("Credits: ");
            int.TryParse(Console.ReadLine(), out int credits);

            var c = new Course { Title = title ?? "", Credits = credits };
            db.Courses.Add(c);
            db.SaveChanges();

            Console.WriteLine("Course created.");
        }

        static void ReadCourses(AppDbContext db)
        {
            Console.WriteLine("\n=== Courses ===");
            foreach (var c in db.Courses)
            {
                Console.WriteLine($"{c.Id}: {c.Title} ({c.Credits} credits)");
            }
        }

        static void UpdateCourse(AppDbContext db)
        {
            Console.Write("Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var c = db.Courses.Find(id);
            if (c == null) { Console.WriteLine("Not found."); return; }

            Console.Write("New title: ");
            var title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title)) c.Title = title;

            Console.Write("New credits: ");
            if (int.TryParse(Console.ReadLine(), out int credits)) c.Credits = credits;

            db.SaveChanges();
            Console.WriteLine("Updated.");
        }

        static void DeleteCourse(AppDbContext db)
        {
            Console.Write("Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var c = db.Courses.Find(id);
            if (c == null) { Console.WriteLine("Not found."); return; }

            db.Courses.Remove(c);
            db.SaveChanges();
            Console.WriteLine("Deleted.");
        }

        // ============================
        // STUDENT PROFILE CRUD
        // ============================

        static void ProfileMenu(AppDbContext db)
        {
            Console.WriteLine("\n=== Profile Menu ===");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.Write("Choose: ");

            var c = Console.ReadLine();

            switch (c)
            {
                case "1": CreateProfile(db); break;
                case "2": ReadProfiles(db); break;
                case "3": UpdateProfile(db); break;
                case "4": DeleteProfile(db); break;
            }
        }

        static void CreateProfile(AppDbContext db)
        {
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("Address: ");
            var addr = Console.ReadLine();

            var p = new StudentProfile { StudentId = id, Address = addr ?? "" };
            db.StudentProfiles.Add(p);
            db.SaveChanges();

            Console.WriteLine("Profile created.");
        }

        static void ReadProfiles(AppDbContext db)
        {
            Console.WriteLine("\n=== Profiles ===");
            foreach (var p in db.StudentProfiles.Include(p => p.Student))
            {
                Console.WriteLine($"{p.StudentId}: {p.Student?.Name} | {p.Address}");
            }
        }

        static void UpdateProfile(AppDbContext db)
        {
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var p = db.StudentProfiles.Find(id);
            if (p == null) { Console.WriteLine("Not found."); return; }

            Console.Write("New address: ");
            var addr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(addr)) p.Address = addr;

            db.SaveChanges();
            Console.WriteLine("Updated.");
        }

        static void DeleteProfile(AppDbContext db)
        {
            Console.Write("Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            var p = db.StudentProfiles.Find(id);
            if (p == null) { Console.WriteLine("Not found."); return; }

            db.StudentProfiles.Remove(p);
            db.SaveChanges();
            Console.WriteLine("Deleted.");
        }

        // ============================
        // ENROLLMENT CRUD
        // ============================

        static void EnrollmentMenu(AppDbContext db)
        {
            Console.WriteLine("\n=== Enrollment Menu ===");
            Console.WriteLine("1. Enroll student");
            Console.WriteLine("2. Read enrollments");
            Console.WriteLine("3. Update grade");
            Console.WriteLine("4. Remove enrollment");
            Console.Write("Choose: ");

            var c = Console.ReadLine();

            switch (c)
            {
                case "1": CreateEnrollment(db); break;
                case "2": ReadEnrollments(db); break;
                case "3": UpdateEnrollment(db); break;
                case "4": DeleteEnrollment(db); break;
            }
        }

        static void CreateEnrollment(AppDbContext db)
        {
            Console.Write("Student ID: ");
            int.TryParse(Console.ReadLine(), out int sid);

            Console.Write("Course ID: ");
            int.TryParse(Console.ReadLine(), out int cid);

            Console.Write("Grade: ");
            var grade = Console.ReadLine();

            var e = new Enrollment { StudentId = sid, CourseId = cid, Grade = grade };
            db.Enrollments.Add(e);
            db.SaveChanges();

            Console.WriteLine("Enrollment created.");
        }

        static void ReadEnrollments(AppDbContext db)
        {
            Console.WriteLine("\n=== Enrollments ===");
            foreach (var e in db.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course))
            {
                Console.WriteLine($"{e.Student?.Name} -> {e.Course?.Title} | Grade: {e.Grade}");
            }
        }

        static void UpdateEnrollment(AppDbContext db)
        {
            Console.Write("Student ID: ");
            int.TryParse(Console.ReadLine(), out int sid);

            Console.Write("Course ID: ");
            int.TryParse(Console.ReadLine(), out int cid);

            var e = db.Enrollments.Find(sid, cid);
            if (e == null) { Console.WriteLine("Not found."); return; }

            Console.Write("New grade: ");
            var grade = Console.ReadLine();
            e.Grade = grade;

            db.SaveChanges();
            Console.WriteLine("Updated.");
        }

        static void DeleteEnrollment(AppDbContext db)
        {
            Console.Write("Student ID: ");
            int.TryParse(Console.ReadLine(), out int sid);

            Console.Write("Course ID: ");
            int.TryParse(Console.ReadLine(), out int cid);

            var e = db.Enrollments.Find(sid, cid);
            if (e == null) { Console.WriteLine("Not found."); return; }

            db.Enrollments.Remove(e);
            db.SaveChanges();
            Console.WriteLine("Deleted.");
        }
    }
}
