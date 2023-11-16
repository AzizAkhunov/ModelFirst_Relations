using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelFirst.Models;
using System.Diagnostics;

namespace ModelFirst.Configurations
{
    public class StudentTypeConfigure : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);

            builder.HasOne<Teacher>(s => s.Teacher)
            .WithMany(g => g.TeacherStudents)
            .HasForeignKey(s => s.TeacherId);
            
            builder.HasMany<Grade>(s => s.Grades)
            .WithMany(g => g.Students);
        }
    }
}
