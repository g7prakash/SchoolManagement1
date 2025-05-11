using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Interfaces
{
    public interface IPeriodRepository
    {
        Period AddPeriod(Period Period);
        Period UpdatePeriod(Period Period);
        bool DeletePeriod(int Id);
        IEnumerable<Period> GetPeriod();
        Period GetPeriodById(int Id);
    }
}
