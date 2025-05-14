using Microsoft.AspNetCore.Mvc;

namespace st10161149_prog7311_part2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
