namespace StudentManagement.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<BikeCategory> BikeCategories { get; set; }
    }
}