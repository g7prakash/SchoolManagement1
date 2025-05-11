using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class TimeTableEntry
    {
        public int Id { get; set; }
        [ForeignKey("SchoolClass")]
        public virtual int SchoolClassId { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        [ForeignKey("Subject")]
        public virtual int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        [ForeignKey("Teacher")]
        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("Period")]
        public virtual int PeriodId { get; set; }
        public virtual Period Period { get; set; }

        public virtual DayOfWeek Day { get; set; } // Enum for Monday, Tuesday, etc.

        public TimeTableEntry()
        {
        }

        public TimeTableEntry(int id, int schoolClassId, int subjectId, int teacherId, int periodId, DayOfWeek day)
        {
            Id = id;
            SchoolClassId = schoolClassId;
            SubjectId = subjectId;
            TeacherId = teacherId;
            PeriodId = periodId;
            Day = day;
        }
    }
}
