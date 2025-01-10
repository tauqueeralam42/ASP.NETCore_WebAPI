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
    }
}
