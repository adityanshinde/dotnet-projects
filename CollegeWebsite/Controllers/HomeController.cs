/*
 Study notes - Controllers/HomeController.cs

 What this file contains:
 - A minimal MVC controller class `HomeController` that derives from `Controller` and has an
   `Index` action returning a `View()` for the home page.

 Key concepts & keywords used here:
 - namespace: groups related classes.
 - class HomeController : Controller: inheritance from ASP.NET Core MVC `Controller` base class.
 - IActionResult: an abstract return type from controller actions representing HTTP responses.
 - View(): returns a ViewResult which renders a Razor view (.cshtml).

 MVC workflow notes:
 - A request matching the route (e.g., / or /Home/Index) is dispatched to this action.
 - The controller prepares any data (model) and calls `View(model)` to render HTML.
 - `Controller` provides helper methods like `View()`, `RedirectToAction()`, `NotFound()`, etc.

 When to modify:
 - Add extra actions to respond to other pages (About, Contact), or add parameters for route data.

*/
using Microsoft.AspNetCore.Mvc;

namespace CollegeWebsite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
