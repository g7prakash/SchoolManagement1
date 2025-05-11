using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolManagement.DataAccess.Extensions;
using SchoolManagement.DataAccess.ViewModels;
using StudentManagement.Models;

namespace StudentManagement.DataAccess.Contexts
{
    public class SchoolDbContext : IdentityDbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options): base(options) { }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<SchoolClass> SchoolClass { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<TimeTableEntry> TimeTableEntries { get; set; }
        public DbSet<User> JWTUsers { get; set; }

        //public DbSet<Student> Students { get; set; }
        //public DbSet<Courses> Courses { get; set; }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BikeCategory> BikeCategories { get; set; }
        public DbSet<EmployeeDepartmentViewModel> EmployeeDepartmentViewModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
            //modelBuilder.Entity<Student>().ToTable("tbl_student");
            //modelBuilder.Entity<Courses>().ToTable("tbl_studentCourse");

            modelBuilder.Entity<Bike>().ToTable("tbl_bikes");
            modelBuilder.Entity<Brand>().ToTable("tbl_brands");
            modelBuilder.Entity<Category>().ToTable("tbl_categories");
            modelBuilder.Entity<BikeCategory>().ToTable("tbl_bike_categories");

            //modelBuilder.Entity<Employees>().Property(p => p.RowVersion).IsRowVersion();
            //modelBuilder.Entity<Student>()
            //.HasOne(b => b.Courses)
            //.WithMany(br => br.Students)
            //.HasForeignKey(b => b.CourseId);

            //modelBuilder.Entity<Courses>()
            //.HasOne(b => b.Student)
            //.WithMany(br => br.StudentCourses)
            //.HasForeignKey(b => b.StudentId);

            modelBuilder.Entity<Bike>()
            .HasOne(b => b.Brand)
            .WithMany(br => br.Bikes)
            .HasForeignKey(b => b.BrandId);

            // 🔗 Many-to-Many: Bike ↔ Category via BikeCategory
            modelBuilder.Entity<BikeCategory>()
                .HasKey(bc => new { bc.BikeId, bc.CategoryId });

            modelBuilder.Entity<BikeCategory>()
                .HasOne(bc => bc.Bike)
                .WithMany(b => b.BikeCategories)
                .HasForeignKey(bc => bc.BikeId);

            modelBuilder.Entity<BikeCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BikeCategories)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<EmployeeDepartmentViewModel>().HasNoKey().ToView(null);
        }
    }
}
