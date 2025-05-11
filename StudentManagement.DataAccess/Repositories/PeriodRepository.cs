using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Interfaces;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.Models;

namespace SchoolManagement.Models.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly SchoolDbContext _context;

        public PeriodRepository(SchoolDbContext context)
        {
            this._context = context;
        }
        public Period AddPeriod(Period Period)
        {
            _context.Add(Period);
            _context.SaveChanges();
            return Period;
        }

        public bool DeletePeriod(int Id)
        {
            var Period = _context.Period.FirstOrDefault(c => c.Id == Id);
            if (Period != null)
            {
                _context.Remove(Period);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Period> GetPeriod()
        {
            return _context.Period;
        }

        public Period GetPeriodById(int Id)
        {
            return _context.Period.FirstOrDefault(c => c.Id == Id);
        }

        public Period UpdatePeriod(Period Period)
        {
            var PeriodObj = _context.Period.Attach(Period);
            PeriodObj.State = EntityState.Modified;
            _context.SaveChanges();
            return Period;
        }
    }
}

