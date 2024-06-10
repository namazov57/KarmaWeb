using Karma.Business.Modules.AccountModule.Commands.EmailConfirmCommand;
using Karma.Business.Modules.AccountModule.Commands.RegisterCommand;
using Karma.Business.Modules.AccountModule.Commands.SigninCommand;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Karma.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [Route("/signin.html")]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/signin.html")]
        public async Task<IActionResult> Signin(SigninRequest request)
        {
            
            await mediator.Send(request);
            var callback = Request.Query["ReturnUrl"];

            if (!string.IsNullOrWhiteSpace(callback))
            {
                return Redirect(callback);
            }

            return RedirectToAction("index", "home");

          
        }

        [AllowAnonymous]
       [Route("/register.html")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/register.html")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Signin));
        }

        [AllowAnonymous]
        [Route("/email-confirm.html")]
        public async Task<IActionResult> EmailConfirm(EmailConfirmRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Signin));
        }

        [Route("/accessdenied.html")]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [Route("/logout.html")]
        public async Task<IActionResult> Logout()
        {
            await Request.HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
