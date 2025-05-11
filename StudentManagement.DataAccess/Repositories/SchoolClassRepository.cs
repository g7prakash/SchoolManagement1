using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.Models;

namespace SchoolManagement.Models.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private readonly SchoolDbContext _context;

        public SchoolClassRepository(SchoolDbContext context)
        {
            this._context = context;
        }
        public SchoolClass AddSchoolClass(SchoolClass schoolClass)
        {
            _context.Add(schoolClass);
            _context.SaveChanges();
            return schoolClass;
        }

        public bool DeleteSchoolClass(int Id)
        {
            var schoolClass = _context.SchoolClass.FirstOrDefault(c => c.Id == Id);
            if (schoolClass != null)
            {
                _context.Remove(schoolClass);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<SchoolClass> GetSchoolClasses()
        {
            return _context.SchoolClass;
        }

        public SchoolClass GetSchoolClassesById(int Id)
        {
            return _context.SchoolClass.FirstOrDefault(c => c.Id == Id);
        }

        public SchoolClass UpdateSchoolClass(SchoolClass schoolClass)
        {
            var schoolClassObj = _context.SchoolClass.Attach(schoolClass);
            schoolClassObj.State = EntityState.Modified;
            _context.SaveChanges();
            return schoolClass;
        }
    }
}

