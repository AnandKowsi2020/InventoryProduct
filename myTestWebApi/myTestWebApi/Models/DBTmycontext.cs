using Microsoft.EntityFrameworkCore;

namespace myTestWebApi.Models
{
    public class DBTmycontext : DbContext
    {
        public DBTmycontext(DbContextOptions<DBTmycontext> options) : base(options) { }

        public DbSet<clsEmployees> TEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<clsEmployees>().ToTable("Employees");
        }
    }

    public class DBTFContext : DbContext
    {
        public DBTFContext(DbContextOptions<DBTFContext> options) : base(options) { }

        public DbSet<clsEmployees> TEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<clsEmployees>().ToTable("Employees");
        }
    }
}



