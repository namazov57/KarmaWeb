using Microsoft.AspNetCore.Mvc;

namespace KarmaWebSite.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } public IActionResult Elements()
        {
            return View();
        } public IActionResult Login()
        {
            return View();
        }
     public IActionResult Tracking()
        {
            return View();
        }
    }
}
