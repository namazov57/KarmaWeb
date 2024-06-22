using Karma.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Infrastructure.Entites.Membership;

namespace Karma.Data.Persistences.Configurations
{
    class ProductRateEntityConfiguration : IEntityTypeConfiguration<ProductRate>
    {
        public void Configure(EntityTypeBuilder<ProductRate> builder)
        {
            builder.Property(m => m.UserId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ProductId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Rate).HasColumnType("int").IsRequired();

            builder.HasKey(m => new { m.UserId, m.ProductId });
            builder.ToTable("ProductRates");


            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<KarmaUser>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
