using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using SchoolManagement.DataAccess.ViewModels;
using StudentManagement.Models;

namespace SchoolManagement.Controllers
{
    public class TimeTableController : Controller
    {
        /// <summary>
        /// Logger for Teacher Controller
        /// </summary>
        private readonly ILogger<TimeTableController> _logger;


        /// <summary>
        /// Period Repository Instance
        /// </summary>
        private readonly ITimeTableEntryRepository _timeTable;
        private readonly ITeacherRepository _teacher;
        private readonly ISchoolClassRepository _schoolClass;

        public TimeTableController(ILogger<TimeTableController> logger, ITimeTableEntryRepository timeTable, ITeacherRepository teacher, ISchoolClassRepository schoolClass)
        {
            _logger = logger;
            _timeTable = timeTable;
            _teacher = teacher;
            _schoolClass = schoolClass;
        }
        // GET: TimeTableController
        [Route("TimeTable")]
        [Route("TimeTable/Index")]
        public ActionResult Index()
        {
            var schoolClass = _schoolClass.GetSchoolClasses();
            var teacher = _teacher.GetTeachers();
            return View(new ClassTimeTableViewModel { GetSchools = schoolClass, GetTeachers = teacher});
        }

        // GET: TimeTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimeTableEntry timeTable)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _timeTable.AddTimeTableEntry(timeTable);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTableController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _timeTable.GetTimeTableEntryById(id);
            return View(model);
        }

        // POST: TimeTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TimeTableEntry timeTable)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _timeTable.UpdateTimeTableEntry(timeTable);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTableController/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["DeleteSuccess"] = _timeTable.DeleteTimeTableEntry(id) ? "Item deleted successfully." : "";
            return RedirectToAction(nameof(Index));
        }

        public ActionResult GetTimeTableByClassId(int? schoolClassId)
        {
            try
            {
                var classPeriodDayWise = _timeTable.GetTimeTableForClass(schoolClassId??13);
                return View("ClassTimeTable", classPeriodDayWise); 
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetTimeTableByTeacherId(int? teacherId)
        {
            try
            {
                var teacherTimeTable = _timeTable.GetTimeTableForTeacher(teacherId??1);
                return View("TeacherTimeTable", teacherTimeTable);
            }
            catch
            {
                return View();
            }
        }
    }
}
