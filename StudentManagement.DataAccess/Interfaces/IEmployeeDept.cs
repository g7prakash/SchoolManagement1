using SchoolManagement.DataAccess.ViewModels;
using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Interfaces
{
    public interface IEmployeeDept
    {
        Employees AddEmployee(Employees Employee);
        Employees UpdateEmployee(Employees Employee);
        bool DeleteEmployee(int Id);
        IEnumerable<Employees> GetEmployee();
        Employees GetEmployeeById(int Id);
        IEnumerable<Departments> GetDepartment();
        Departments GetDepartmentById(int Id);
        List<EmployeeDepartmentViewModel> GetEmployeeDepartment();
        EmployeeDepartmentViewModel NthHighestSalary(int nth);
        Task<List<Employees>> GetEmployeeDepartment(int departmentId);
        Task<List<Employees>> GetEmployees();
    }
}
