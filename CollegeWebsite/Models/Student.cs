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
