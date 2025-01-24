using Microsoft.EntityFrameworkCore;
using myTestWebApi.DTO; // Ensure this namespace is correct for your DTO classes

namespace myTestWebApi.Models
{
    public class MyDBTcontext : DbContext
    {
        // Constructor to pass DbContextOptions to the base DbContext
        public MyDBTcontext(DbContextOptions<MyDBTcontext> options) : base(options) { }

        // Define DbSet for Employees table
        public DbSet<clsEmployees> TEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call base method (optional, but good practice)
            base.OnModelCreating(modelBuilder);

            // Map the Employees entity to the Employees table
            modelBuilder.Entity<clsEmployees>().ToTable("Employees");
        }







    }
}
