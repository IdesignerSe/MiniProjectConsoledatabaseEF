using System;
using ConsoleApp.Data;
using ConsoleApp.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EF Core Console App is running.");

            using var db = new AppDbContext();

            Console.WriteLine("Students in database:");
            foreach (var student in db.Students)
            {
                Console.WriteLine($"- {student.Name} ({student.Email})");
            }
        }
    }
}
