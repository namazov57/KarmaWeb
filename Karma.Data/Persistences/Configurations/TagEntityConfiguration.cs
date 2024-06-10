using Karma.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karma.Data.Persistences.Configurations
{
    class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();

            builder.ConfigureAsAuditable();


            builder.HasKey(m => m.Id);
            builder.ToTable("Tags");
        }
    }
}
