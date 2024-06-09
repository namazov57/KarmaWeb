using Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand;
using Karma.Business.Modules.BlogPostModule.Commands.BlogPostEditCommand;
using Karma.Business.Modules.BlogPostModule.Commands.BlogPostRemoveCommand;
using Karma.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery;
using Karma.Business.Modules.BlogPostModule.Queries.BlogPostGetByIdQuery;
using Karma.Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoryGetAllRequest());

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostAddRequest model)
        {
          
            
           var response= await mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(BlogPostGetByIdRequest request)
        {
            var categories = await mediator.Send(new CategoryGetAllRequest());

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogPostEditRequest request)
        {
            

           var response= await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(BlogPostGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Remove(BlogPostRemoveRequest request)
        {
            await mediator.Send(request);


            var response = await mediator.Send(new BlogPostGetAllRequest());


            return PartialView("_Body", response);
        }
    }
}
