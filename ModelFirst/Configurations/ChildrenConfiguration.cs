using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelFirst.Models;

namespace ModelFirst.Configurations
{
    public class ChildrenConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Father)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.FatherId);
        }
    }
}
