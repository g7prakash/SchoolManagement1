using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Interfaces
{
    public interface ITeacherRepository
    {
        Teacher AddTeacher(Teacher Teacher);
        Teacher UpdateTeacher(Teacher Teacher);
        bool DeleteTeacher(int Id);
        IEnumerable<Teacher> GetTeachers();
        Teacher GetTeacherById(int Id);
    }
}
