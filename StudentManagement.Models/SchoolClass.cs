namespace StudentManagement.Models
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "Grade 10"
        public string Section { get; set; } // e.g., "A"
        public SchoolClass()
        {
        }

        public SchoolClass(int id, string name, string section)
        {
            Id = id;
            Name = name;
            Section = section;
        }
    }
}
