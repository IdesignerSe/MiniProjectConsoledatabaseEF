using System;
using ConsoleApp.Data;
using ConsoleApp.Models;

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
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Read Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateStudent(db);
                        break;

                    case "2":
                        ReadStudents(db);
                        break;

                    case "3":
                        UpdateStudent(db);
                        break;

                    case "4":
                        DeleteStudent(db);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // CREATE
        static void CreateStudent(AppDbContext db)
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter email: ");
            var email = Console.ReadLine();

            var student = new Student
            {
                Name = name ?? "",
                Email = email ?? ""
            };

            db.Students.Add(student);
            db.SaveChanges();

            Console.WriteLine("Student created.");
        }

        // READ
        static void ReadStudents(AppDbContext db)
        {
            Console.WriteLine("\n=== Students ===");

            foreach (var s in db.Students)
            {
                Console.WriteLine($"{s.Id}: {s.Name} - {s.Email}");
            }
        }

        // UPDATE
        static void UpdateStudent(AppDbContext db)
        {
            Console.Write("Enter student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var student = db.Students.Find(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("New name (leave empty to keep current): ");
            var newName = Console.ReadLine();

            Console.Write("New email (leave empty to keep current): ");
            var newEmail = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName))
                student.Name = newName;

            if (!string.IsNullOrWhiteSpace(newEmail))
                student.Email = newEmail;

            db.SaveChanges();
            Console.WriteLine("Student updated.");
        }

        // DELETE
        static void DeleteStudent(AppDbContext db)
        {
            Console.Write("Enter student ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var student = db.Students.Find(id);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            db.Students.Remove(student);
            db.SaveChanges();

            Console.WriteLine("Student deleted.");
        }
    }
}
