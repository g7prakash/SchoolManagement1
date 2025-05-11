using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Interfaces;
using SchoolManagement.DataAccess.ViewModels;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.Models;

namespace SchoolManagement.Models.Repositories
{
    public class EmployeeDeptRepository : IEmployeeDept
    {
        private readonly SchoolDbContext _context;

        public EmployeeDeptRepository(SchoolDbContext context)
        {
            this._context = context;
        }
        public Employees AddEmployee(Employees employee)
        {
            _context.Employees.FromSqlRaw("EXEC dbo.GetEmployeesDepartmentWise @DepartmentId",
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@DateOfBirth", employee.DateOfBirth),
                new SqlParameter("@Gender", employee.Gender),
                new SqlParameter("@DepartmentId", employee.DepartmentID),
                new SqlParameter("@Salary", employee.Salary),
                new SqlParameter("@Salary", employee.HireDate));
            _context.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public bool DeleteEmployee(int Id)
        {
            var Employee = _context.Employees.FirstOrDefault(c => c.EmployeeID == Id);
            if (Employee != null)
            {
                _context.Remove(Employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Departments> GetDepartment()
        {
            return _context.Departments;
        }

        public Departments GetDepartmentById(int Id)
        {
            return _context.Departments.FirstOrDefault(c => c.DepartmentID == Id);
        }

        public IEnumerable<Employees> GetEmployee()
        {
            return _context.Employees;
        }

        public Employees GetEmployeeById(int Id)
        {
            return _context.Employees.FirstOrDefault(c => c.EmployeeID == Id);
        }

        public async Task<List<Employees>> GetEmployeeDepartment(int departmentId)
        {
            try
            {
                var employeeDetails = await _context.Employees.FromSqlRaw("EXEC dbo.GetEmployeesDepartmentWise @DepartmentId",
                new SqlParameter("@DepartmentId", departmentId))
                .ToListAsync();
                return employeeDetails;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public Employees UpdateEmployee(Employees Employee)
        {
            var EmployeeObj = _context.Employees.Attach(Employee);
            EmployeeObj.State = EntityState.Modified;
            _context.SaveChanges();
            return Employee;
        }

        public List<EmployeeDepartmentViewModel> GetEmployeeDepartment()
        {
            return (from a in _context.Employees
                    join
                    b in _context.Departments on a.DepartmentID equals b.DepartmentID
                    select new EmployeeDepartmentViewModel
                    {
                        EmployeeId = a.EmployeeID,
                        EmployeeName = $"{a.FirstName} {a.LastName}",
                        Salary = a.Salary,
                        DepartmentName = b.DepartmentName
                    }).ToList();

        }

        public EmployeeDepartmentViewModel NthHighestSalary(int nth)
        {
            return GetEmployeeDepartment().OrderByDescending(x => x.Salary).Skip(nth - 1).FirstOrDefault();
        }

        public async Task<List<Employees>> GetEmployees()
        {
            try
            {
                var employeeDetails = await _context.Employees.ToListAsync();
                return employeeDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

