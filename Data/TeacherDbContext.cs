using CoreCrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCrudOperation.Data
{
    public class TeacherDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TeacherDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "vishal", Subject = "Java" },
                new Teacher { Id = 2, Name = "amruta", Subject = "C#" },
                new Teacher { Id = 3, Name = "vicky", Subject = "python" }
            );
        }
    }
}
