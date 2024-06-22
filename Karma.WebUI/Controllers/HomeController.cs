using Karma.Business.Modules.SubscribeModule.Commands.SubscribeApproveCommand;
using Karma.Business.Modules.SubscribeModule.Commands.SubscribeTicketCommand;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarmaWebSite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private readonly IEmailService emailService;

        public HomeController(IMediator mediator,IEmailService emailService )
        {
            this.mediator = mediator;
            this.emailService = emailService;
        }
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

      

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeTicketRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                error = false,
                message = $"Abunəliyinizi təsdiq etmək üçün '{request.Email}' e-poçt adresinə daxil olub sizə göndərilən linkə keçid edin!"
            });
        }


        [Route("/subscribe-approve.html")]
        public async Task<IActionResult> SubscribeApprove(SubscribeApproveRequest request)
        {
            await mediator.Send(request);

            TempData["Message"] = "Abuneliyiniz tesdiqlendi";
            return RedirectToAction(nameof(Index));
        }
    }
}
