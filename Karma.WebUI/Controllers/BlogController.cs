using Microsoft.AspNetCore.Mvc;

namespace KarmaWebSite.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BLog()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
