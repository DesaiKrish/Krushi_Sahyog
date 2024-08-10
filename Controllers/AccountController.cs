using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAppDb.Data;
using MyAppDb.Models;

namespace BulkyWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context; // Replace with your DbContext

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Implement user authentication logic here
                var user = _context.User.FirstOrDefault(u => u.email == model.email && u.password == model.password);

                if (user != null)
                {
                    // Successful login, redirect to home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)

            {
                // Create a new User instance
                var user = new User
                {
                    name = model.name,
                    email = model.email,
                    password = model.password, // Consider hashing the password before saving
                    phone = model.phone,
                    role = model.role,
                    createdAt = DateTime.Now
                };

                // Add user to the database
                _context.User.Add(user);
                _context.SaveChanges();

                // Successful registration, redirect to login page or another desired page
                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }
    }
}