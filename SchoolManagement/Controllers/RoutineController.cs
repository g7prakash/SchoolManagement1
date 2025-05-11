using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using SchoolManagement.Models;
using System.Diagnostics;

namespace SchoolManagement.Controllers
{
    [Authorize]
    public class RoutineController : Controller
    {
        private readonly ILogger<RoutineController> _logger;
        private readonly IEmployeeDept _employeeDept;

        public RoutineController(ILogger<RoutineController> logger, IEmployeeDept employeeDept)
        {
            _logger = logger;
            _employeeDept = employeeDept;
        }

        public IActionResult Index()
        {
            return View(_employeeDept.GetEmployeeDepartment());
        }

        public IActionResult GetNthHighestSalary(int salRank)
        {
            var model = _employeeDept.NthHighestSalary(salRank);
            return View("HighestSalary", model);
        }

        public async Task<IActionResult> GetDepartWiseEmployee(int employeeId)
        {
            var data = await _employeeDept.GetEmployeeDepartment(employeeId);
            return View("DepartmentEmployee", data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
