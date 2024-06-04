using Karma.Data;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacutererRepository _manufacutererRepository;

        public ManufacturerController(IManufacutererRepository manufacutererRepository)
        {
            _manufacutererRepository = manufacutererRepository;
        }
        public IActionResult Index()
        {

            var manufacturers = _manufacutererRepository.GetAll(c => c.DeletedBy == null);

            return View(manufacturers);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Manufacturer manufacturer)
        {

            _manufacutererRepository.Add(manufacturer);
            _manufacutererRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var dbmanufacturer = _manufacutererRepository.Get(x => x.Id == id);

            if (dbmanufacturer == null) return NotFound();

            return View(dbmanufacturer);
        }

        [HttpPost]
        public IActionResult Edit(Manufacturer manufacturer)
        {
            _manufacutererRepository.Edit(manufacturer);
            _manufacutererRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var dbmanufacturer = _manufacutererRepository.Get(x => x.Id == id);

            if (dbmanufacturer == null) return NotFound();

            return View(dbmanufacturer);
        }

        public IActionResult Remove(int id)
        {
            var dbmanufacturer = _manufacutererRepository.Get(x => x.Id == id);
            _manufacutererRepository.Remove(dbmanufacturer);
            _manufacutererRepository.Save();

            var manufacturers = _manufacutererRepository.GetAll(c => c.DeletedBy == null);


            return PartialView("_Body", manufacturers);
        }
    }
}
