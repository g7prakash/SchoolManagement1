using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models.Enums
{
    public class MenuItems
    {
        public enum MenuItem
        {
            Routine = 1,
            SchoolClass = 2,
            Teacher = 3,
            Period = 4,
            Subject = 5,
            TimeTable = 6,
            Account = 7,
            Administration = 8,
        }

        enum SubMenuItem
        {
            Add = 1,
            Modify = 2,
            Replace = 3,
            Delete = 4,
        }

        public enum ClassSection
        {
            [Display(Name = "A")]
            A,
            [Display(Name = "B")]
            B,
            [Display(Name = "C")]
            C,
            [Display(Name = "D")]
            D,
            [Display(Name = "E")]
            E,
            [Display(Name = "F")]
            F,
            [Display(Name = "G")]
            G,
            [Display(Name = "H")]
            H
        }
    }
}
