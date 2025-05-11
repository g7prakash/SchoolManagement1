using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Period
    {
        public int Id { get; set; }
        public string PeriodName { get; set; } // e.g., "1st Period"
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Period() { }
        
        public Period(int id, string periodName, TimeSpan startTime, TimeSpan endTime)
        {
            Id = id;
            PeriodName = periodName;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
