using SchoolManagement.DataAccess.ViewModels;
using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Interfaces
{
    public interface ITimeTableEntryRepository
    {
        TimeTableEntry AddTimeTableEntry(TimeTableEntry TimeTableEntry);
        TimeTableEntry UpdateTimeTableEntry(TimeTableEntry TimeTableEntry);
        bool DeleteTimeTableEntry(int Id);
        IEnumerable<TimeTableEntry> GetTimeTableEntrys();
        TimeTableEntry GetTimeTableEntryById(int Id);
        ClassTimeTableViewModel GetTimeTableForClass(int classId);
        ClassTimeTableViewModel GetTimeTableForTeacher(int teacherId);
    }
}
