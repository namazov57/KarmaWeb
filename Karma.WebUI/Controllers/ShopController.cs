using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarmaWebSite.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMediator mediator;
        public ShopController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
          

            return View();
        }

        

       

       
    }
}
