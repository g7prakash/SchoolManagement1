using Microsoft.EntityFrameworkCore;
using SchoolManagement.DataAccess.Interfaces;
using SchoolManagement.DataAccess.ViewModels;
using StudentManagement.DataAccess.Contexts;
using StudentManagement.Models;

namespace SchoolManagement.Models.Repositories
{
    public class TimeTableEntryRepository : ITimeTableEntryRepository
    {
        private readonly SchoolDbContext _context;

        public TimeTableEntryRepository(SchoolDbContext context)
        {
            this._context = context;
        }
        public TimeTableEntry AddTimeTableEntry(TimeTableEntry TimeTableEntry)
        {
            _context.Add(TimeTableEntry);
            _context.SaveChanges();
            return TimeTableEntry;
        }

        public bool DeleteTimeTableEntry(int Id)
        {
            var TimeTableEntry = _context.TimeTableEntries.FirstOrDefault(c => c.Id == Id);
            if (TimeTableEntry != null)
            {
                _context.Remove(TimeTableEntry);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<TimeTableEntry> GetTimeTableEntrys()
        {
            return _context.TimeTableEntries;
        }

        public TimeTableEntry GetTimeTableEntryById(int Id)
        {
            return _context.TimeTableEntries.FirstOrDefault(c => c.Id == Id);
        }

        public TimeTableEntry UpdateTimeTableEntry(TimeTableEntry TimeTableEntry)
        {
            var TimeTableEntryObj = _context.TimeTableEntries.Attach(TimeTableEntry);
            TimeTableEntryObj.State = EntityState.Modified;
            _context.SaveChanges();
            return TimeTableEntry;
        }

        public ClassTimeTableViewModel GetTimeTableForClass(int classId)
        {
            var query = (from timeTable in _context.TimeTableEntries
                         join period in _context.Period on timeTable.PeriodId equals period.Id
                         join teacher in _context.Teacher on timeTable.TeacherId equals teacher.Id
                         join subject in _context.Subject on timeTable.SubjectId equals subject.Id
                         join schoolClass in _context.SchoolClass on timeTable.SchoolClassId equals schoolClass.Id
                         where schoolClass.Id == classId
                         orderby timeTable.Day ascending
                         select new
                         {
                             PeriodId = period.Id,
                             TeacherName = $"{teacher.Name}",
                             TeacherSubject = $"{teacher.Subjects}",
                             SubjectName = $"{subject.Name}",
                             ClassName = $"{schoolClass.Name} {schoolClass.Section}",
                             PeriodName = $"{period.PeriodName}",
                             DayName = $"{timeTable.Day}"
                         }).ToList();
            var classTeacher = query.Where(x => x.DayName == DayOfWeek.Monday.ToString() && x.PeriodId == 1).Select(x => x.TeacherName).FirstOrDefault();
            var assignedTeachersforClass = query.Distinct().Select(x => new AssignedTeachers { TeacherName = x.TeacherName, TeacherSubject = x.TeacherSubject }).Distinct().ToList();
            var className = query.Select(c => c.ClassName).Distinct().FirstOrDefault();
            var periodDayWise = query
                    .GroupBy(c => c.DayName)
                    .Select(g => new TimeTablePeriodDay
                    {
                        Day = g.Key,
                        Period1 = g.Where(x => x.PeriodName == "1st").Select(x => x.SubjectName).FirstOrDefault(),
                        Period2 = g.Where(x => x.PeriodName == "2nd").Select(x => x.SubjectName).FirstOrDefault(),
                        Period3 = g.Where(x => x.PeriodName == "3rd").Select(x => x.SubjectName).FirstOrDefault(),
                        Period4 = g.Where(x => x.PeriodName == "4th").Select(x => x.SubjectName).FirstOrDefault(),
                        Period5 = g.Where(x => x.PeriodName == "5th").Select(x => x.SubjectName).FirstOrDefault(),
                        Period6 = g.Where(x => x.PeriodName == "6th").Select(x => x.SubjectName).FirstOrDefault(),
                        Period7 = g.Where(x => x.PeriodName == "7th").Select(x => x.SubjectName).FirstOrDefault()
                    }).ToList();

            return new ClassTimeTableViewModel
            {
                ClassName = className,
                ClassTeacher = classTeacher,
                AssignedTeachersforClass = assignedTeachersforClass.DistinctBy(t=>t.TeacherName).ToList(),
                TimeTablePeriodDayWise = periodDayWise
            };
        }

        public ClassTimeTableViewModel GetTimeTableForTeacher(int teacherId)
        {
            var query = (from timeTable in _context.TimeTableEntries
                         join period in _context.Period on timeTable.PeriodId equals period.Id
                         join teacher in _context.Teacher on timeTable.TeacherId equals teacher.Id
                         join subject in _context.Subject on timeTable.SubjectId equals subject.Id
                         join schoolClass in _context.SchoolClass on timeTable.SchoolClassId equals schoolClass.Id
                         where timeTable.TeacherId == teacherId
                         select new
                         {
                             TeacherName = $"{teacher.Name}",
                             SubjectName = $"{subject.Name}",
                             ClassName = $"{schoolClass.Name} {schoolClass.Section}",
                             PeriodName = $"{period.PeriodName}",
                         }).ToList();
            return new ClassTimeTableViewModel { TeacherTimeTables = query.Distinct().Select(x => new TeacherTimeTable { TeacherName = x.TeacherName, SubjectName = x.SubjectName, ClassName = x.ClassName, PeriodName = x.PeriodName }).DistinctBy(t=>t.TeacherName).ToList() };
        }

        public ClassTimeTableViewModel GetClassesWithSection(int teacherId)
        {
            var query = (from timeTable in _context.TimeTableEntries
                         join period in _context.Period on timeTable.PeriodId equals period.Id
                         join teacher in _context.Teacher on timeTable.TeacherId equals teacher.Id
                         join subject in _context.Subject on timeTable.SubjectId equals subject.Id
                         join schoolClass in _context.SchoolClass on timeTable.SchoolClassId equals schoolClass.Id
                         where timeTable.TeacherId == teacherId
                         select new
                         {
                             TeacherName = $"{teacher.Name}",
                             SubjectName = $"{subject.Name}",
                             ClassName = $"{schoolClass.Name} {schoolClass.Section}",
                             PeriodName = $"{period.PeriodName}",
                         }).ToList();
            return new ClassTimeTableViewModel { TeacherTimeTables = query.Distinct().Select(x => new TeacherTimeTable { TeacherName = x.TeacherName, SubjectName = x.SubjectName, ClassName = x.ClassName, PeriodName = x.PeriodName }).DistinctBy(t => t.TeacherName).ToList() };
        }
    }
}

