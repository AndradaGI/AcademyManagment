// Data/DbInitializer.cs
using System.Linq;
using AcademyManagement.Models;
using AcademyManagment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AcademyManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Academies.Any())
            {
                return; // DB has been seeded
            }

            var academies = new Academy[]
            {
                new Academy { Name = "Tech Academy", Address = "Strada1" },
                new Academy { Name = "Code Academy", Address = "Strada2" },
                new Academy { Name = "Test Academy", Address = "Strada3" },
                new Academy { Name = "Test4 Academy", Address = "Strada4" },
                new Academy { Name = "Test10 Academy", Address = "Strada4" }
            };
            context.Academies.AddRange(academies);
            context.SaveChanges();

            // Obține Id-urile după ce au fost salvate
            var techAcademy = context.Academies.First(a => a.Name == "Tech Academy");
            var codeAcademy = context.Academies.First(a => a.Name == "Code Academy");
            var testAcademy = context.Academies.First(a => a.Name == "Test Academy");

            var courses = new Course[]
            {
                new Course { Title = "C# Fundamentals", AcademyId = techAcademy.Id },
                new Course { Title = "ASP.NET Core", AcademyId = techAcademy.Id},
                new Course { Title = "Java Basics", AcademyId = codeAcademy.Id },
                new Course { Title = "Test Basics", AcademyId = testAcademy.Id }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student { FullName = "Andrada" },
                new Student { FullName = "Student1" },
                new Student { FullName = "Oana" }
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            var csharpCourse = context.Courses.First(c => c.Title == "C# Fundamentals");
            var aspNetCourse = context.Courses.First(c => c.Title == "ASP.NET Core");

            var enrollments = new Enrollment[]
            {
                new Enrollment { CourseId = csharpCourse.Id, StudentId = students[0].Id },
                new Enrollment { CourseId = aspNetCourse.Id, StudentId = students[1].Id }
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }

        internal static void Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            throw new NotImplementedException();
        }
    }
}
