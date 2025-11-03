/*
 Study notes - Controllers/StudentsController.cs

 What this file contains:
 - `StudentsController` demonstrates an MVC controller with in-memory sample data, two actions
   (`Index` and `Details`), and use of model classes (`Student`, `Course`).

 Key concepts & keywords used here:
 - using: imports namespaces (e.g., Microsoft.AspNetCore.Mvc, CollegeWebsite.Models, System.Linq).
 - Controller: base class from ASP.NET Core MVC providing helper methods and features.
 - IActionResult: flexible return type for actions; can represent views, redirects, NotFound, etc.
 - static readonly: defines application-scoped sample data used here only for demonstration.
 - LINQ (FirstOrDefault, Any): methods for querying collections (requires System.Linq).

 MVC workflow and notes:
 - `Index()` prepares a model (list of students) and returns `View(model)`. The corresponding view
   is typically `Views/Students/Index.cshtml` and is strongly-typed to consume the model.
 - `Details(int id)` shows how controller actions accept route parameters (model binding). The runtime
   maps an integer `id` from the URL to this parameter.
 - `NotFound()` returns a 404 response when a requested resource doesn't exist.

 When to refactor:
 - Replace static in-memory lists with a service or DbContext (dependency injection) for testability and persistence.
 - Keep controllers thin: move business logic into services or the model layer.

*/
using Microsoft.AspNetCore.Mvc;
using CollegeWebsite.Models;
using System.Linq;

namespace CollegeWebsite.Controllers
{
    public class StudentsController : Controller
    {
        // In-memory sample data to demonstrate models and controller actions
        private static readonly List<Course> SampleCourses = new()
        {
            new Course(1, "Introduction to Programming", 4),
            new Course(2, "Data Structures", 3),
            new Course(3, "Databases", 3)
        };

        private static readonly List<Student> SampleStudents = new()
        {
            new Student(1, "Alice", 20) { },
            new Student(2, "Bob", 17) { },
            new Student(3, "Charlie", 22) { }
        };

        public IActionResult Index()
        {
            // Enroll a student to show relationships
            SampleStudents[0].Enroll(SampleCourses[0]);
            SampleStudents[0].Enroll(SampleCourses[1]);

            return View(SampleStudents);
        }

        public IActionResult Details(int id)
        {
            var student = SampleStudents.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
