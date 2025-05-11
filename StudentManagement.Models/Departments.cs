using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace StudentManagement.Models
{
    public class Departments
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Departments() { }
        public Departments(int departmentID, string departmentName)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
        }
    }
}
