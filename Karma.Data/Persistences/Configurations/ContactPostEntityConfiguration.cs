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
    class ContactPostEntityConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1, 1);

            builder.Property(m => m.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.Email).IsRequired().HasColumnType("varchar");
            builder.Property(m => m.Subject).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.Message).IsRequired().HasColumnType("nvarchar");
            builder.Property(m => m.Answer).HasColumnType("nvarchar");
            builder.Property(m => m.AnsweredBy).HasColumnType("int");
            builder.Property(m => m.AnsweredAt).HasColumnType("datetime");
            //builder.ConfigureAsAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");
        }
    }
}
