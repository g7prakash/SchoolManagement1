using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Interfaces
{
    public interface ISubjectRepository
    {
        Subject AddSubject(Subject Subject);
        Subject UpdateSubject(Subject Subject);
        bool DeleteSubject(int Id);
        IEnumerable<Subject> GetSubject();
        Subject GetSubjectById(int Id);
    }
}
