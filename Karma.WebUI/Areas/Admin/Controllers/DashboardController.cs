﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {
        }

       [Authorize("admin.dashboard.index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
