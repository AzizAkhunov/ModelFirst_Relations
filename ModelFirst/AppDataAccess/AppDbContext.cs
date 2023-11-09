using Microsoft.EntityFrameworkCore;
using ModelFirst.Models;

namespace ModelFirst.AppDataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }
        public DbSet<Father> Fathers { get; set; }
        public DbSet<Child> Children { get; set; }
    }
}
