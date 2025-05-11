using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class SchoolClassController : Controller
    {
        private readonly ILogger<SchoolClassController> _logger;
        private readonly ISchoolClassRepository _schoolClass;
        public SchoolClassController(ILogger<SchoolClassController> logger, ISchoolClassRepository schoolClass)
        {
            _logger = logger;
            this._schoolClass = schoolClass;
        }

        [Route("SchoolClass")]
        [Route("SchoolClass/Index")]
        public IActionResult Index()
        {
            var model = _schoolClass.GetSchoolClasses();
            return View(model);
        }

        [HttpGet]
        [Route("SchoolClass/Details/{id}")]
        public IActionResult Details(int id)
        {
            var model = _schoolClass.GetSchoolClassesById(id);
            return View(model);
        }

        [Route("SchoolClass/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            TempData["DeleteSuccess"] = _schoolClass.DeleteSchoolClass(id) ? "Item deleted successfully." : "";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                _schoolClass.AddSchoolClass(schoolClass);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _schoolClass.GetSchoolClassesById(id);
            return View(model);
        }

        public IActionResult Edit(SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                _schoolClass.UpdateSchoolClass(schoolClass);
            }
            return RedirectToAction("Index");
        }
    }
}
