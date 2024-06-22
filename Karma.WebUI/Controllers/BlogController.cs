using Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommentCommand;
using Karma.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery;
using Karma.Business.Modules.BlogPostModule.Queries.BlogPostGetBySlugQuery;
using Karma.Business.Modules.BlogPostModule.Queries.BlogPostRecentsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KarmaWebSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator mediator;

        public BlogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            request.OnlyPublished = true;
            var response = await mediator.Send(request);
            var recents = await mediator.Send(new BlogPostRecentsRequest() { Size = 3 });
            ViewBag.Recents = recents;

            return View(response);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("blogs/{slug}")]
        public async Task<IActionResult> Details(BlogPostGetBySlugRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddComment(BlogPostAddCommentRequest request)
        {
            var response = await mediator.Send(request);
            return PartialView("_Comment", response);
            //return Json(response);
        }
    }
}
