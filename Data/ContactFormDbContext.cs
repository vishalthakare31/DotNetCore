using CoreCrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCrudOperation.Data
{
    public class ContactFormDbContext :DbContext
    {
        private readonly IConfiguration configuration;

        public ContactFormDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<ContactForm> ContactForms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactForm>().HasData(
                new ContactForm {Id=1 , Name = "vishal",  Email = "Vishalthakare31@gmail.com" , Message=" Fresher lookimg for an Job" },
                new ContactForm { Id= 2 , Name = "mayur", Email = "mayurthakare@gmail.com", Message = " Fresher lookimg for an Job" }

            );
        }
    }
}
