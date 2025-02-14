﻿using Karma.Infrastructure.Entites;
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
    class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(m => m.ShippingCountry).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.ShippingCity).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.ShippingAddress).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Postcode).HasColumnType("varchar(100)").IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(m => m.Phone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(m => m.CouponCode).HasColumnType("varchar(100)");
            builder.Property(m => m.Amount).HasColumnType("decimal").IsRequired().HasPrecision(18, 2);
            builder.Property(m => m.DiscountAmount).HasColumnType("decimal").HasPrecision(18, 2);
            builder.Property(m => m.State).HasColumnType("tinyint").IsRequired();

            builder.HasKey(m => m.Id);
            builder.ToTable("Orders");

            builder.HasOne<KarmaUser>().WithMany().
                HasForeignKey(m => m.CreatedBy).
                HasPrincipalKey(m => m.Id).
                OnDelete(DeleteBehavior.NoAction);

        }
    }
}
