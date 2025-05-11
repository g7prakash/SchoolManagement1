using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.Models;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class PeriodController : Controller
    {
        /// <summary>
        /// Logger for Period Controller
        /// </summary>
        private readonly ILogger<PeriodController> _logger;


        /// <summary>
        /// Period Repository Instance
        /// </summary>
        private readonly IPeriodRepository _period;

        /// <summary>
        /// Constructor to Initialize class
        /// </summary>
        /// <param name="logger">logger</param>
        /// <param name="dbContext">DB context</param>
        public PeriodController(ILogger<PeriodController> logger, IPeriodRepository period)
        {
            _logger = logger;
            this._period = period;
        }

        [Route("Period")]
        [Route("Period/Index")]
        // GET: PeriodController
        public ActionResult Index()
        {
            var model = _period.GetPeriod();
            return View(model);

        }

        // GET: PeriodController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Period period)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _period.AddPeriod(period);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeriodController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _period.GetPeriodById(id);
            return View(model);
        }

        // POST: PeriodController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Period period)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _period.UpdatePeriod(period);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeriodController/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["DeleteSuccess"] = _period.DeletePeriod(id) ? "Item deleted successfully." : "";
            return RedirectToAction(nameof(Index));
        }
    }
}
