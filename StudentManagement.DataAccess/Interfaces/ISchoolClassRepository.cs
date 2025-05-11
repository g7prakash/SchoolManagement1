using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Interfaces
{
    public interface ISchoolClassRepository
    {
        SchoolClass AddSchoolClass(SchoolClass schoolClass);
        SchoolClass UpdateSchoolClass(SchoolClass schoolClass);
        bool DeleteSchoolClass(int Id);
        IEnumerable<SchoolClass> GetSchoolClasses();
        SchoolClass GetSchoolClassesById(int Id);
    }
}
