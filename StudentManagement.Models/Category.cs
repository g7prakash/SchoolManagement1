namespace StudentManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<BikeCategory> BikeCategories { get; set; }
    }
}