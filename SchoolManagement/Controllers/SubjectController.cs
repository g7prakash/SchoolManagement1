using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        /// <summary>
        /// Logger for Subject Controller
        /// </summary>
        private readonly ILogger<SubjectController> _logger;

        /// <summary>
        /// Period Repository Instance
        /// </summary>
        private readonly ISubjectRepository _subject;

        public SubjectController(ILogger<SubjectController> logger, ISubjectRepository subject)
        {
            _logger = logger;
            _subject = subject;
        }

        [Route("Subject")]
        [Route("Subject/Index")]
        // GET: SubjectController
        public ActionResult Index()
        {
            var model = _subject.GetSubject();
            return View(model);
        }

        [Route("Subject/Details/{id}")]
        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            var model = _subject.GetSubjectById(id);
            return View(model);
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subject.AddSubject(subject);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _subject.GetSubjectById(id);
            return View(model);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subject.UpdateSubject(subject);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubjectController/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["DeleteSuccess"] = _subject.DeleteSubject(id) ? "Item deleted successfully." : "";
            return RedirectToAction(nameof(Index));
        }
    }
}
