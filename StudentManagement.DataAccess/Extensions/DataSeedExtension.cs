using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace SchoolManagement.DataAccess.Extensions
{
    public static class DataSeedExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolClass>().HasData(
                new SchoolClass { Id = 1, Name = "I", Section = "A" },
                new SchoolClass(2, "I", "B"),
                new SchoolClass(3, "I", "C"),
                new SchoolClass(4, "I", "D"),
                new SchoolClass(5, "I", "E"),
                new SchoolClass(6, "I", "F"),
                new SchoolClass(7, "II", "A"),
                new SchoolClass(8, "II", "B"),
                new SchoolClass(9, "II", "C"),
                new SchoolClass(10, "II", "D"),
                new SchoolClass(11, "II", "E"),
                new SchoolClass(12, "II", "F"),
                new SchoolClass(13, "III", "A"),
                new SchoolClass(14, "III", "B"),
                new SchoolClass(15, "III", "C"),
                new SchoolClass(16, "III", "D"),
                new SchoolClass(17, "III", "E"),
                new SchoolClass(18, "III", "F"),
                new SchoolClass(19, "IV", "A"),
                new SchoolClass(20, "IV", "B"),
                new SchoolClass(21, "IV", "C"),
                new SchoolClass(22, "IV", "D"),
                new SchoolClass(23, "IV", "E"),
                new SchoolClass(24, "IV", "F"),
                new SchoolClass(25, "V", "A"),
                new SchoolClass(26, "V", "B"),
                new SchoolClass(27, "V", "C"),
                new SchoolClass(28, "V", "D"),
                new SchoolClass(29, "V", "E"),
                new SchoolClass(30, "V", "F"),
                new SchoolClass(31, "VI", "A"),
                new SchoolClass(32, "VI", "B"),
                new SchoolClass(33, "VI", "C"),
                new SchoolClass(34, "VI", "D"),
                new SchoolClass(35, "VI", "E"),
                new SchoolClass(36, "VI", "F"));

            modelBuilder.Entity<Period>().HasData(
                new Period { Id = 1, PeriodName = "1st", StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 45, 0) },
                new Period(2, "2nd", new TimeSpan(8, 45, 0), new TimeSpan(9, 30, 0)),
                new Period(3, "3rd", new TimeSpan(9, 30, 0), new TimeSpan(10, 15, 0)),
                new Period(4, "4th", new TimeSpan(10, 15, 0), new TimeSpan(11, 0, 0)),
                new Period(5, "5th", new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0)),
                new Period(6, "6th", new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0)),
                new Period(7, "7th", new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0)),
                new Period(8, "8th", new TimeSpan(8, 0, 0), new TimeSpan(8, 45, 0))
                );

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "English", ShortName = "English" },
                new Subject { Id = 2, Name = "Hindi", ShortName = "Hindi" },
                new Subject { Id = 3, Name = "Sanskrit", ShortName = "Sanskrit" },
                new Subject { Id = 4, Name = "Mathematics", ShortName = "English" },
                new Subject { Id = 5, Name = "Social Science", ShortName = "S. Sc." },
                new Subject { Id = 6, Name = "Science", ShortName = "EVS" },
                new Subject { Id = 7, Name = "Computer", ShortName = "Computer" },
                new Subject ( 8, "Music","Music" ),
                new Subject ( 9, "Library","Library" ),
                new Subject ( 10, "Game","Game" ),
                new Subject ( 11, "Drawing","Drawing" ),
                new Subject ( 12, "Activity", "Activity"),
                new Subject ( 13, "General Knowledge", "G. K."),
                new Subject ( 14, "Moral Education", "M. Ed."),
                new Subject ( 15, "Physical Education", "P. Ed.")
                );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "MR. ANUPAM ANURAG", Qualified = "NA", Subjects = "HINDI+ M.ED" },
                new Teacher(2, "MR.Dummy ENGLISH Teacher6", "NA", "ENGLISH + SPOKEN ENG"),
                new Teacher(3, "MS.GAYATRI KUMARI", "NA", "MATHEMATICS"),
                new Teacher(4, "MR.MANOJ KUMAR", "NA", "EVS + ACTIVITY"),
                new Teacher(5, "MR.ABHISHEK KR.SINGH", "NA", "S.SC. + ACT+ G.K"),
                new Teacher(6, "MRS.PALLAVI KUMARI", "NA", "GAME"),
                new Teacher(7, "MR.RAUSHAN KUMAR", "NA", "LIBRARY"),
                new Teacher(8, "MRS.RICHA KUMARI", "NA", "MUSIC"),
                new Teacher(9, "MRS.NIDHI", "NA", "COMPUTER"),
                new Teacher(10, "MR.ARUN KUMAR", "NA", "DRAWING"),
                new Teacher(11, "MR.MAHENDRA KUMAR", "NA", "HINDI + M.ED"),
                new Teacher(12, "MS.MUSKAN THAKUR", "NA", "ENGLISH + SPOKEN ENG"),
                new Teacher(13, "MRS.R.K.SAH", "NA", "MUSIC"),
                new Teacher(14, "MRS.SNEHA", "NA", "EVS + ACTIVITY"),
                new Teacher(15, "MRS.RUCHI KUMARI", "NA", "HINDI + M.ED"),
                new Teacher(16, "MR.Dummy ENGLISH Teacher4", "NA", "ENGLISH + SPOKEN ENG"),
                new Teacher(17, "MRS.KATYAYINI", "NA", "MATHEMATICS"),
                new Teacher(18, "MR.AMAN KUMAR", "NA", "S.SC. + ACTIVITY"),
                new Teacher(19, "MRS.PRAKRITI MOHANTI", "NA", "HINDI + M.ED"),
                new Teacher(20, "MR.Dummy ENGLISH Teacher1", "NA", "ENGLISH + SPOKEN ENG"),
                new Teacher(21, "MR.RAJESH KUMAR", "NA", "MATHEMATICS"),
                new Teacher(22, "MR.ABHIJEET KUMAR THAKUR", "NA", "EVS + ACTIVITY"),
                new Teacher(23, "MS.KANCHAN BHARTI", "NA", "ENGLISH + SPOKEN ENG"),
                new Teacher(24, "MR.NADIM QUASMI", "NA", "LIBRARY"),
                new Teacher(25, "MR.SURESH KUMAR", "NA", "MATHEMATICS"),
                new Teacher(26, "MS.AMRITA KUMARI", "NA", "EVS + ACTIVITY"),
                new Teacher(27, "MR.AVINASH KUMAR", "NA", "S.SC. + ACT + G.K."),
                new Teacher(28, "MRS.MEGHA MITI", "NA", "COMPUTER"),
                new Teacher(30, "MR.PRASHANT KUMAR", "NA", "MATHEMATICS"),
                new Teacher(31, "MR.PRABIN RANJAN", "NA", "EVS + ACTIVITY"),
                new Teacher(32, "MR.NIKHIL NISHANT", "NA", "S.SC. + ACTIVITY"),
                new Teacher(33, "MRS.VIJETA KUMARI", "NA", "HINDI + M.ED"));

            //Class III A
            modelBuilder.Entity<TimeTableEntry>().HasData(
                new TimeTableEntry(1, 13, 2, 1, 1, DayOfWeek.Monday),
new TimeTableEntry(2, 13, 5, 5, 2, DayOfWeek.Monday),
new TimeTableEntry(3, 13, 8, 8, 3, DayOfWeek.Monday),
new TimeTableEntry(4, 13, 4, 3, 4, DayOfWeek.Monday),
new TimeTableEntry(5, 13, 1, 2, 5, DayOfWeek.Monday),
new TimeTableEntry(6, 13, 6, 4, 6, DayOfWeek.Monday),
new TimeTableEntry(7, 13, 2, 1, 1, DayOfWeek.Tuesday),
new TimeTableEntry(8, 13, 5, 5, 2, DayOfWeek.Tuesday),
new TimeTableEntry(9, 13, 7, 9, 3, DayOfWeek.Tuesday),
new TimeTableEntry(10, 13, 4, 3, 4, DayOfWeek.Tuesday),
new TimeTableEntry(11, 13, 1, 2, 5, DayOfWeek.Tuesday),
new TimeTableEntry(12, 13, 6, 4, 6, DayOfWeek.Tuesday),
new TimeTableEntry(13, 13, 2, 1, 1, DayOfWeek.Wednesday),
new TimeTableEntry(14, 13, 5, 5, 2, DayOfWeek.Wednesday),
new TimeTableEntry(15, 13, 7, 9, 3, DayOfWeek.Wednesday),
new TimeTableEntry(16, 13, 4, 3, 4, DayOfWeek.Wednesday),
new TimeTableEntry(17, 13, 1, 2, 5, DayOfWeek.Wednesday),
new TimeTableEntry(18, 13, 6, 4, 6, DayOfWeek.Wednesday),
new TimeTableEntry(19, 13, 2, 1, 1, DayOfWeek.Thursday),
new TimeTableEntry(20, 13, 5, 5, 2, DayOfWeek.Thursday),
new TimeTableEntry(21, 13, 10, 6, 3, DayOfWeek.Thursday),
new TimeTableEntry(22, 13, 4, 3, 4, DayOfWeek.Thursday),
new TimeTableEntry(23, 13, 1, 2, 5, DayOfWeek.Thursday),
new TimeTableEntry(24, 13, 6, 4, 6, DayOfWeek.Thursday),
new TimeTableEntry(25, 13, 2, 1, 1, DayOfWeek.Friday),
new TimeTableEntry(26, 13, 5, 5, 2, DayOfWeek.Friday),
new TimeTableEntry(27, 13, 11, 10, 3, DayOfWeek.Friday),
new TimeTableEntry(28, 13, 4, 3, 4, DayOfWeek.Friday),
new TimeTableEntry(29, 13, 1, 2, 5, DayOfWeek.Friday),
new TimeTableEntry(30, 13, 6, 4, 6, DayOfWeek.Friday),
new TimeTableEntry(31, 13, 2, 1, 1, DayOfWeek.Saturday),
new TimeTableEntry(32, 13, 5, 5, 2, DayOfWeek.Saturday),
new TimeTableEntry(33, 13, 9, 7, 3, DayOfWeek.Saturday),
new TimeTableEntry(34, 13, 4, 3, 4, DayOfWeek.Saturday),
new TimeTableEntry(35, 13, 1, 2, 5, DayOfWeek.Saturday),
new TimeTableEntry(36, 13, 6, 4, 6, DayOfWeek.Saturday));

            //modelBuilder.Entity<User>().HasData(
            //    new User(1, "Test", "User - 04-05-2025", "test", BCrypt.Net.BCrypt.HashPassword("test")),
            //    new User(2, "Admin", "User - 05-05-2025", "admin", BCrypt.Net.BCrypt.HashPassword("admin")),
            //    new User(3, "Super Admin", "User - 05-05-2025", "sadmin", BCrypt.Net.BCrypt.HashPassword("sadmin")));
        }
    }
}
