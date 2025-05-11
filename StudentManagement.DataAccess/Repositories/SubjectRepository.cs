using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.Models;

namespace SchoolManagement.Models.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolDbContext _context;

        public SubjectRepository(SchoolDbContext context)
        {
            this._context = context;
        }
        public Subject AddSubject(Subject Subject)
        {
            _context.Add(Subject);
            _context.SaveChanges();
            return Subject;
        }

        public bool DeleteSubject(int Id)
        {
            var Subject = _context.Subject.FirstOrDefault(c => c.Id == Id);
            if (Subject != null)
            {
                _context.Remove(Subject);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Subject> GetSubject()
        {
            return _context.Subject;
        }

        public Subject GetSubjectById(int Id)
        {
            return _context.Subject.FirstOrDefault(c => c.Id == Id);
        }

        public Subject UpdateSubject(Subject Subject)
        {
            var SubjectObj = _context.Subject.Attach(Subject);
            SubjectObj.State = EntityState.Modified;
            _context.SaveChanges();
            return Subject;
        }
    }
}

