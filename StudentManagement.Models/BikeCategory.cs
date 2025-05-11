namespace StudentManagement.Models
{
    public class BikeCategory
    {
        public int BikeId { get; set; }
        public Bike Bike { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}