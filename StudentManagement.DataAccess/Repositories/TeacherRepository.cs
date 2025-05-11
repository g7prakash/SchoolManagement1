using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.Models;

namespace SchoolManagement.Models.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _context;

        public TeacherRepository(SchoolDbContext context)
        {
            this._context = context;
        }
        public Teacher AddTeacher(Teacher Teacher)
        {
            _context.Add(Teacher);
            _context.SaveChanges();
            return Teacher;
        }

        public bool DeleteTeacher(int Id)
        {
            var Teacher = _context.Teacher.FirstOrDefault(c => c.Id == Id);
            if (Teacher != null)
            {
                _context.Remove(Teacher);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return _context.Teacher;
        }

        public Teacher GetTeacherById(int Id)
        {
            return _context.Teacher.FirstOrDefault(c => c.Id == Id);
        }

        public Teacher UpdateTeacher(Teacher Teacher)
        {
            var TeacherObj = _context.Teacher.Attach(Teacher);
            TeacherObj.State = EntityState.Modified;
            _context.SaveChanges();
            return Teacher;
        }
    }
}

