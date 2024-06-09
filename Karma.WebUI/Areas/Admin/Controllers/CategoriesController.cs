using Karma.Business.Modules.CategoriesModule.Commands.CategoryAddCommand;
using Karma.Business.Modules.CategoriesModule.Commands.CategoryEditCommand;
using Karma.Business.Modules.CategoriesModule.Commands.CategoryRemoveCommand;
using Karma.Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery;
using Karma.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(CategoryGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoryGetAllRequest());
            ViewBag.categoryId = new SelectList(categories,"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddRequest model)
        {
            await mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(CategoryGetByIdRequest request)
        {
           
            var response = await mediator.Send(request);

            var categories = await mediator.Send(new CategoryGetAllRequest());
            ViewBag.categoryId = new SelectList(categories, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(CategoryGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Remove(CategoryRemoveRequest request)
        {
            await mediator.Send(request);


            var response = await mediator.Send(new CategoryGetAllRequest());


            return PartialView("_Body", response);
        }
    }
}
