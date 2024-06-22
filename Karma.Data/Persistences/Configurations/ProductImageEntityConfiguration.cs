using Karma.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Data.Persistences.Configurations
{
    class ProductImageEntityConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);

            builder.Property(m => m.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Property(m => m.IsMain).IsRequired().HasColumnType("bit");
            builder.Property(m => m.IsMain).IsRequired().HasColumnType("bit");
            builder.Property(m => m.ProductId).IsRequired().HasColumnType("int");
            //builder.ConfigureAsAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("ProductImages");
        }
    }
}
