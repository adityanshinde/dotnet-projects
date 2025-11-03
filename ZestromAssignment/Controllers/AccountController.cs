using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZestromAssignment.Data;
using ZestromAssignment.ViewModels;

namespace ZestromAssignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;

        public AccountController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == vm.Username && u.Password == vm.Password);
            if (user == null)
            {
                vm.ErrorMessage = "Invalid username or password";
                return View(vm);
            }

            // For learning/demo: don't implement real auth here. Redirect to a simple welcome page.
            return RedirectToAction("Welcome");
        }

        public IActionResult Welcome()
        {
            return Content("Login successful! Welcome.");
        }
    }
}
