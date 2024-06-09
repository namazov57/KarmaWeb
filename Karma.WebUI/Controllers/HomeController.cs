using Karma.Business.Modules.SubscribeModule.Commands.SubscribeApproveCommand;
using Karma.Business.Modules.SubscribeModule.Commands.SubscribeTicketCommand;
using Karma.Data;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace KarmaWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private readonly IEmailService _emailService;

        public HomeController(IMediator mediator, IEmailService emailService)
        {
            this.mediator = mediator;
            _emailService = emailService;
        }
        public IActionResult Index()
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


        public async Task<IActionResult> SubscribeApprove(SubscribeApproveRequest request)
        {
            await mediator.Send(request);

            TempData["Message"] = "Abuneliyiniz tesdiqlendi";
            return RedirectToAction(nameof(Index));
        }
    }
}
