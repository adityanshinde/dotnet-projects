/*
 Study notes - Models/Student.cs

 What this file contains:
 - `Student` class that inherits from `Person` and demonstrates inheritance, collection handling,
   constructors calling base constructors, method overriding, and simple validation.

 Key concepts & keywords used here:
 - using: imports namespaces (e.g., System.Collections.Generic, System.Linq).
 - List<T>: generic collection from System.Collections.Generic; used to store enrolled courses.
 - private set: allows reading the property publicly but only modifying it from within the class.
 - : base(name): calls the base class constructor to initialize inherited state.
 - Any(): LINQ method (System.Linq) used to check for existing items in the list.
 - override: provides a new implementation for a virtual method defined in the base class.

 Methods and workflow:
 - Constructor Student(int id, string name, int age): initializes Id, Age and creates an empty Enrolled list.
 - Enroll(Course course): checks whether the student is already enrolled in the course using LINQ Any()
   and only adds if not present (simple duplication guard).
 - IsAdult(): returns boolean indicating whether the student's age is 18 or older.
 - Introduce(): overrides Person.Introduce() to include student-specific information.

 Example usage:
 var s = new Student(1, "Alice", 20);
 s.Enroll(new Course(1, "Intro", 3));
 Console.WriteLine(s.IsAdult()); // true

*/
using System.Collections.Generic;
using System.Linq;

namespace CollegeWebsite.Models
{
    public class Student : Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public List<Course> Enrolled { get; private set; }

        public Student(int id, string name, int age) : base(name)
        {
            Id = id;
            Age = age;
            Enrolled = new List<Course>();
        }

        public void Enroll(Course course)
        {
            if (!Enrolled.Any(c => c.Id == course.Id))
                Enrolled.Add(course);
        }

        public bool IsAdult() => Age >= 18;

        public override string Introduce() => $"Hi, I'm {Name} and I'm {Age} years old.";
    }
}
