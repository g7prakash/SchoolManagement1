namespace StudentManagement.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualified { get; set; }
        public string Subjects { get; set; }
        public Teacher() { }
        public Teacher(int id, string name, string qualified, string subjects)
        {
            Id = id;
            Name = name;
            Qualified = qualified;
            Subjects = subjects;
        }
    }
}
