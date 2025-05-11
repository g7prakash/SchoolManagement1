using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CourseId { get; set; }
        public Courses Courses { get; set; }
        public ICollection<Courses> StudentCourses { get; set; }
    }
}
