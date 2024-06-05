using Karma.Business.Modules.TagsModule.Commands.TagAddCommand;
using Karma.Business.Modules.TagsModule.Commands.TagEditCommand;
using Karma.Business.Modules.TagsModule.Commands.TagRemoveCommand;
using Karma.Business.Modules.TagsModule.Queries.TagGetAllQuery;
using Karma.Business.Modules.TagsModule.Queries.TagGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly IMediator mediator;
        public TagController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        public async Task<IActionResult> Index(TagGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

       
        public async Task<IActionResult> Details(TagGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Create(TagAddRequest model)
        {
            await mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Edit(TagGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(TagEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        
        public async Task<IActionResult> Delete(TagRemoveRequest request)
        {
            await mediator.Send(request);


            var response = await mediator.Send(new TagGetAllRequest());


            return PartialView("_Body", response);
        }
    }
}
