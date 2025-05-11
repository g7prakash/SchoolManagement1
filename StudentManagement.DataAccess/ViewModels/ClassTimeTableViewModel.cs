using StudentManagement.Models;

namespace SchoolManagement.DataAccess.ViewModels
{
    public class ClassTimeTableViewModel
    {
        public string ClassTeacher { get; set; }
        public string ClassName { get; set; }
        public List<AssignedTeachers> AssignedTeachersforClass { get; set; }
        public List<TimeTablePeriodDay> TimeTablePeriodDayWise { get; set; }
        public List<TeacherTimeTable> TeacherTimeTables { get; set; }

        public IEnumerable<SchoolClass> GetSchools { get; set; }
        public IEnumerable<Teacher> GetTeachers { get; set; }

    }

    public class AssignedTeachers
    {
        public string TeacherName { get; set; }
        public string TeacherSubject { get; set; }
    }

    public class TimeTablePeriodDay
    {
        public string Day { get; set; }
        public string Period1 { get; set; }
        public string Period2 { get; set; }
        public string Period3 { get; set; }
        public string Period4 { get; set; }
        public string Period5 { get; set; }
        public string Period6 { get; set; }
        public string Period7 { get; set; }
    }

    public class TeacherTimeTable
    {
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string ClassName { get; set; }
        public string PeriodName { get; set; }
    }
}
