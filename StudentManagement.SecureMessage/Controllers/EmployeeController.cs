using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudentManagement.SecureMessage.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDept _employee;
        public EmployeeController(IEmployeeDept employee)
        {
            _employee = employee;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddEmployee(Employees employees)
        {
            var data = _employee.AddEmployee(employees);
            //var emp = _employee.UpdateEmployee(employees);
            return Ok(data);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateEmployee(Employees employees)
        {
            var emp = _employee.UpdateEmployee(employees);
            return Ok();
        }

        [ActionName("GetById")]
        public void Get(int id)
        { }

        [ActionName("GetByString")]
        public int Get(string id)
        {
            return 0;
        }

        [ActionName("GetByGUID")]
        public void Get(Guid id)
        { }
    }
}
