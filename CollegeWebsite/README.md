# CollegeWebsite — Learning MVC, C# OOP and Design

This is a small, educational ASP.NET Core MVC project intended to teach the basic workflow of a C# web application and the core OOP and MVC concepts.

Goals
- Demonstrate how Models, Views and Controllers interact.
- Show simple C# OOP features (encapsulation, inheritance, constructors, methods, polymorphism).
- Provide a tiny, runnable web app you can extend (students and courses sample).

Repository layout (important files)
- `CollegeWebsite.csproj` — project file and target framework.
- `Program.cs` — app startup (services and routing).
- `Models/Person.cs`, `Models/Student.cs`, `Models/Course.cs` — OOP examples and data shapes.
- `Controllers/HomeController.cs`, `Controllers/StudentsController.cs` — controller actions and sample in-memory data.
- `Views/Shared/_Layout.cshtml`, `Views/_ViewStart.cshtml` — shared layout and view start.
- `Views/Home/Index.cshtml`, `Views/Students/Index.cshtml`, `Views/Students/Details.cshtml` — Razor views.
- `wwwroot/css/site.css` — simple styling for the example.

How the app works (request flow)
1. A browser requests a URL. The routing defined in `Program.cs` maps the URL to a controller/action.
2. The Controller (example: `StudentsController.Index`) prepares data (here: in-memory sample lists) and returns a View.
3. The View (`.cshtml`) renders HTML using the strongly-typed model passed from the controller.
4. The browser displays the HTML; static files (CSS) are served from `wwwroot`.

Quick start (PowerShell)

```powershell
cd "c:\Users\adity\OneDrive\Desktop\clg project\dot net\dot net study\CollegeWebsite"
dotnet restore
dotnet build
dotnet run
```

Open the URL printed by `dotnet run` (e.g. `http://localhost:5000`) and open `/Students` to see the sample data.

Detailed module breakdown

Models
- `Person` (base class)
	- Purpose: shows inheritance and encapsulation. Has a `Name` property, a constructor, and a virtual `Introduce()` method.
	- OOP lessons: constructors, properties (get/set), virtual methods for polymorphism.

- `Student` (inherits `Person`)
	- Purpose: adds `Id`, `Age` and an `Enrolled` list of `Course` objects.
	- Methods: `Enroll(Course)` (demonstrates list operations and simple validation), `IsAdult()` and an overridden `Introduce()`.
	- OOP lessons: inheritance (`: Person`), overriding methods, encapsulation of the `Enrolled` collection with a private setter.

- `Course`
	- Purpose: simple data holder for course id, title and credits. Includes `Summary()` to return a human-readable string.

Controllers
- `HomeController`
	- Minimal controller that returns the home page view.

- `StudentsController`
	- Contains in-memory sample lists `SampleCourses` and `SampleStudents` used for demonstration (no database yet).
	- Actions:
		- `Index()` — populates relationships (enrollments) and returns the list of students to the `Students/Index` view.
		- `Details(int id)` — finds a student by id and returns the `Students/Details` view or `NotFound()`.
	- Design lessons: how controllers create models and pass them to views, and how to structure sample/test data.

Views
- Razor views under `Views/Students` and `Views/Home` use strongly-typed models (e.g., `@model IEnumerable<CollegeWebsite.Models.Student>`).
- `Views/Shared/_Layout.cshtml` defines a common header, nav and footer — this teaches separation of layout and content.

Styling
- `wwwroot/css/site.css` contains minimal styles to make the pages readable; static files are served by `app.UseStaticFiles()` in `Program.cs`.

Program.cs and app startup
- `builder.Services.AddControllersWithViews()` registers MVC services.
- Routing is configured with `app.MapControllerRoute(...)` where default controller/action are `Home/Index`.

Target framework note
- The sample `CollegeWebsite.csproj` is set to a target framework. If you get an error saying a runtime is missing, either install the matching .NET runtime (recommended) or change the `<TargetFramework>` in `CollegeWebsite.csproj` to a runtime you have installed (e.g., `net10.0` on preview machines).

Common troubleshooting
- "You must install or update .NET to run this application": install the runtime version requested (link shown by `dotnet run`) or retarget the project as described above.
- Compilation errors about missing namespaces (e.g., `Any()`): ensure the file has `using System.Linq;` when using LINQ methods.

Suggested hands-on exercises (progression)
1. Add a new action to `StudentsController` that filters students by `IsAdult()` and a view to show adults only.
2. Implement Create/Edit/Delete flows for `Student` using forms and POST actions (introduces model binding and form validation).
3. Replace in-memory sample lists with a persistent store using Entity Framework Core and SQLite: scaffold a `DbContext`, run migrations, and persist students and courses.
4. Add a simple admin authentication area (cookie auth) so only authenticated users can modify data.
5. Add unit tests for `Student` methods (e.g., `Enroll`, `IsAdult`) using xUnit or NUnit.

Learning tips
- Read small files at a time: start with `HomeController`, then `StudentsController`, then one model class.
- Run the app often while you change code — the small cycle helps you understand how changes affect output.

Next steps I can help with
- Add CRUD views and controller actions with forms and validation.
- Wire up EF Core and migrations to persist data.
- Add unit tests or step-by-step exercises with answers.

License
This sample is provided for learning and experimentation. Use it freely.

If you want, I can also create a step-by-step exercise file (exercise + solution) that you can work through. Reply with what you'd like next (add CRUD, connect EF Core, or add tests).

Note: Study notes were also added as top-of-file comments in the main source files (`Program.cs`, the files under `Models/`, and `Controllers/`) to explain class responsibilities, key keywords, and typical workflows. Open those files to read the inline explanations.
