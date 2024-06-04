using Karma.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karma.Data.Persistences.Configurations
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasKey(x => x.EmailAddress);

            builder.Property(x => x.EmailAddress).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.IsApproved).HasColumnType("bit");
            builder.Property(x => x.ApprovedAt).HasColumnType("datetime");
            builder.Property(x => x.CreatedAt).HasColumnType("datetime").IsRequired();



            builder.ToTable("Subscribers");
        }

    }


}
