namespace CollegeWebsite.Models
{
    // Base class to demonstrate inheritance and encapsulation
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public virtual string Introduce() => $"Hi, I'm {Name}.";
    }
}
