using learnAspDotNetCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace learnAspDotNetCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Empployees { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
