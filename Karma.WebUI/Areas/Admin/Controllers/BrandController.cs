﻿using Karma.Business.Modules.BrandsModule.Commands.BrandAddCommand;
using Karma.Business.Modules.BrandsModule.Commands.BrandEditCommand;
using Karma.Business.Modules.BrandsModule.Commands.BrandRemoveCommand;
using Karma.Business.Modules.BrandsModule.Queries.BrandGetAllQuery;
using Karma.Business.Modules.BrandsModule.Queries.BrandGetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IMediator mediator;
        public BrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Authorize("admin.brands.index")]
        public async Task<IActionResult> Index(BrandGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [Authorize("admin.brands.details")]
        public async Task<IActionResult> Details(BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }


        [Authorize("admin.brands.create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize("admin.brands.create")]
        public async Task<IActionResult> Create(BrandAddRequest model)
        {
            await mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }

       [Authorize("admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        [HttpPost]
        [Authorize("admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [Authorize("admin.brands.delete")]
        public async Task<IActionResult> Delete(BrandRemoveRequest request)
        {
            await mediator.Send(request);


            var response = await mediator.Send(new BrandGetAllRequest());


            return PartialView("_Body", response);
        }
    }
}
