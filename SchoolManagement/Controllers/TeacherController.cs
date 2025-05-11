using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        /// <summary>
        /// Logger for Teacher Controller
        /// </summary>
        private readonly ILogger<TeacherController> _logger;


        /// <summary>
        /// Period Repository Instance
        /// </summary>
        private readonly ITeacherRepository _teacher;

        public TeacherController(ILogger<TeacherController> logger, ITeacherRepository teacher)
        {
            _logger = logger;
            _teacher = teacher;
        }

        // GET: TeacherController
        [Route("Teacher")]
        [Route("Teacher/Index")]
        public ActionResult Index()
        {
            var model = _teacher.GetTeachers();
            return View(model);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _teacher.AddTeacher(teacher);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _teacher.GetTeacherById(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("PageNotFound", id);
            }
            return View(model);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _teacher.UpdateTeacher(teacher);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["DeleteSuccess"] = _teacher.DeleteTeacher(id) ? "Item deleted successfully." : "";
            return RedirectToAction(nameof(Index));
        }
    }
}
