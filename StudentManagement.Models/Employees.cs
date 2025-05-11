using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }

        [ForeignKey("Departments")]
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
        public DateOnly HireDate { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }
        public Employees()
        {
            
        }
        public Employees(int employeeID, string firstName, string lastName, DateOnly dateOfBirth, string gender, int departmentID, decimal salary, DateOnly hireDate)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            DepartmentID = departmentID;
            Salary = salary;
            HireDate = hireDate;
        }
    }
}
