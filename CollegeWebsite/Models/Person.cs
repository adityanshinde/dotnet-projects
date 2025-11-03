/*
 Study notes - Models/Person.cs

 What this file contains:
 - A base class `Person` used to demonstrate basic C# OOP concepts: encapsulation,
   constructors, properties, and polymorphism via virtual/override.

 Key concepts & keywords used here:
 - class: declares a reference type.
 - public: access modifier making members visible outside the assembly/type.
 - string Name { get; set; }: an auto-implemented property (encapsulation + get/set accessors).
 - constructor Person(string name): initializes new instances; constructors have the same name as the class.
 - virtual: marks a method that derived classes may override to provide specialized behavior.

 Typical uses / workflow:
 - Use `Person` as a base type when you want shared behavior or data (e.g., Name) across derived types.
 - Derived classes (like `Student`) call the base constructor using `: base(name)` to initialize base state.
 - Call `Introduce()` on a `Person` reference; if the runtime object is a `Student` that overrides
   `Introduce()`, the overridden method will run (polymorphism).

 Example:
 var p = new Person("Alex");
 Console.WriteLine(p.Introduce()); // "Hi, I'm Alex."

*/
namespace CollegeWebsite.Models
{
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
