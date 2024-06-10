using Karma.Business.Modules.CategoriesModule.Commands.CategoryAddCommand;
using Karma.Business.Modules.CategoriesModule.Commands.CategoryEditCommand;
using Karma.Business.Modules.CategoriesModule.Commands.CategoryRemoveCommand;
using Karma.Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery;
using Karma.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery;
using Karma.Business.Modules.ColorsModule.Commands.ColorRemoveCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[Authorize("admin.categories.index")]
        public async Task<IActionResult> Index(CategoryGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

       // [Authorize("admin.categories.details")]
        public async Task<IActionResult> Details(CategoryGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

       // [Authorize("admin.categories.create")]
        public async Task<IActionResult> Create()
        {
            var categories = await mediator.Send(new CategoryGetAllRequest());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
       // [Authorize("admin.categories.create")]
        public async Task<IActionResult> Create(CategoryAddRequest request)
        {
            await mediator.Send(request);

            return RedirectToAction(nameof(Index));
        }

       // [Authorize("admin.categories.edit")]
        public async Task<IActionResult> Edit(CategoryGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            var categories = await mediator.Send(new CategoryGetAllRequest());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            return View(response);
        }

        [HttpPost]
       // [Authorize("admin.categories.edit")]
        public async Task<IActionResult> Edit(CategoryEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        //[Authorize("admin.categories.delete")]
        public async Task<IActionResult> Delete(CategoryRemoveRequest request)
        {
            await mediator.Send(request);

            return Json(new
            {
                error = false,
                message = "Qeyd silindi!"
            });
        }
    }
}
