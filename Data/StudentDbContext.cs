using Microsoft.EntityFrameworkCore;
using CoreCrudOperation.Models;
using Microsoft.Extensions.Configuration;

namespace CoreCrudOperation.Data
{
    public class StudentDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public StudentDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, name = "vishal", dept = "developer" },
                new Student { Id = 2, name = "amruta", dept = "tester" },
                new Student { Id = 3, name = "vicky", dept = "tech support" }
            );
        }
    }
}
