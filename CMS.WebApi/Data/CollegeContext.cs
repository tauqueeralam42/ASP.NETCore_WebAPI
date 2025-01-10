using CMS.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.WebApi.Data
{
    public class CollegeContext : DbContext
    {

        public CollegeContext(DbContextOptions<CollegeContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever(); // Ensure EF Core does not try to auto-generate the value
            });
        }

    }
}
