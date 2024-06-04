using Karma.Data;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorRepository _colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public IActionResult Index()
        {

            var colors = _colorRepository.GetAll(c => c.DeletedBy == null);
            return View(colors);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Color color)
        {


            _colorRepository.Add(color);
            _colorRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {


            var dbColor = _colorRepository.Get(x => x.Id == id);

            if (dbColor == null) return NotFound();

            return View(dbColor);
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {

            _colorRepository.Edit(color);
            _colorRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {

            var dbColor = _colorRepository.Get(x => x.Id == id);

            if (dbColor == null) return NotFound();

            return View(dbColor);
        }

        public IActionResult Remove(int id)
        {


            var dbColor = _colorRepository.Get(x => x.Id == id);
            _colorRepository.Remove(dbColor);
            _colorRepository.Save();


            var colors = _colorRepository.GetAll(c => c.DeletedBy == null);


            return PartialView("_Body", colors);
        }


    }
}
