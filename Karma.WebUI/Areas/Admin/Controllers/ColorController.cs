using Karma.Business.Modules.ColorsModule.Commands.ColorAddCommand;
using Karma.Business.Modules.ColorsModule.Commands.ColorEditCommand;
using Karma.Business.Modules.ColorsModule.Commands.ColorRemoveCommand;
using Karma.Business.Modules.ColorsModule.Queries.ColorGetAllQuery;
using Karma.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IMediator _mediator;

        public ColorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(ColorGetAllRequest request)
        {

            var response=await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorAddRequest request)
        {
            await _mediator.Send(request);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(ColorGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
            await _mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(ColorGetByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Remove(ColorRemoveRequest request)
        {


            await _mediator.Send(request);

            return Json(new
            {
                error = false,
                message = "Qeyd silindi!"
            });


            return PartialView("_Body", request);
        }


    }
}
