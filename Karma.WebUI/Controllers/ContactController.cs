using Microsoft.AspNetCore.Mvc;

namespace KarmaWebSite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
