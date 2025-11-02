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
