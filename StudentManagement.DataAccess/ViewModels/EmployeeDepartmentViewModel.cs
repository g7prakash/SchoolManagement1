using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;

namespace SchoolManagement.DataAccess.ViewModels
{
    public class EmployeeDepartmentViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }

    }
}
