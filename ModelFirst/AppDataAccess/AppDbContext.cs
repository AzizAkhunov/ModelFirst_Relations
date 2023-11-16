using Microsoft.EntityFrameworkCore;
using ModelFirst.Configurations;
using ModelFirst.Models;

namespace ModelFirst.AppDataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Father> Fathers { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentTypeConfigure());
        }
    }
}
