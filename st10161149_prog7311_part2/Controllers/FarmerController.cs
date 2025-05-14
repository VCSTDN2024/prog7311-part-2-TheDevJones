using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using st10161149_prog7311_part2.Data;
using st10161149_prog7311_part2.Models;
using BCrypt.Net;


namespace st10161149_prog7311_part2.Controllers
{
    [Authorize(Roles = "Employee")]
    public class FarmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FarmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var farmers = _context.Farmers.Include(f => f.User).ToList();
            return View(farmers);
        }

        public IActionResult Create()
        {
            return View(new FarmerUserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FarmerUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Show validation errors
                return View(model);
            }

            string password = model.Password;

            var user = new User
            {
                Username = model.Username,
                PasswordHash = password,
                Role = "Farmer"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            model.Farmer.UserId = user.UserId;

            _context.Farmers.Add(model.Farmer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
