using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "Mathematics"
        public string ShortName { get; set; } // e.g., "Math"
        public Subject() { }
        public Subject(int id, string name, string shortname)
        {
            Id = id;
            Name = name;
            ShortName = shortname;
        }

    }
}
