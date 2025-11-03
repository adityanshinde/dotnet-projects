/*
 Study notes - Models/Course.cs

 What this file contains:
 - `Course` class: a simple data container (POCO) representing a college course with Id, Title and Credits.

 Key concepts & keywords used here:
 - POCO (Plain Old CLR Object): simple class with properties, used as a model.
 - auto-implemented properties: `int Id { get; set; }` provides a concise property declaration.
 - constructor: initializes the properties when a new Course is created.
 - expression-bodied member: `public string Summary() => ...` is a concise method syntax.

 Typical uses / workflow:
 - Use `Course` as a value object attached to other models (e.g., Student.Enrolled holds courses).
 - Keep model classes small and focused; add helper methods like `Summary()` for display purposes.

 Example usage:
 var c = new Course(1, "Data Structures", 3);
 Console.WriteLine(c.Summary()); // "Data Structures (3 credits)"

*/
namespace CollegeWebsite.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public Course(int id, string title, int credits)
        {
            Id = id;
            Title = title;
            Credits = credits;
        }

        public string Summary() => $"{Title} ({Credits} credits)";
    }
}
