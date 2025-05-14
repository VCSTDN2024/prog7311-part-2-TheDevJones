using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using st10161149_prog7311_part2.Data;
using st10161149_prog7311_part2.Models;

namespace st10161149_prog7311_part2.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult MyProducts()
        {
            var username = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == user.UserId);

            var products = _context.Products.Where(p => p.FarmerId == farmer.FarmerId).ToList();
            return View(products);
        }

        [Authorize(Roles = "Farmer")]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize(Roles = "Farmer")]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var username = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            var farmer = _context.Farmers.FirstOrDefault(f => f.UserId == user.UserId);
            product.FarmerId = farmer.FarmerId;

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("MyProducts");
        }

        [Authorize(Roles = "Employee")]

        public IActionResult FarmerProducts(int farmerId)
        {
            var products = _context.Products
                .Where(p => p.FarmerId == farmerId)
                .Include(p => p.Farmer)
                .ToList();

            ViewBag.FarmerName = products.FirstOrDefault()?.Farmer?.FullName ?? "Unknown Farmer";
            return View(products);
        }


        [Authorize(Roles = "Employee")]
        public IActionResult AllProducts()
        {
            var products = _context.Products.Include(p => p.Farmer).ToList();
            return View(products);
        }
    }
}
