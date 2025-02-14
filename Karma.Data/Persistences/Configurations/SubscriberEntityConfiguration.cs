﻿using Karma.Infrastructure.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Karma.Data.Persistences.Configurations
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(m => m.Approved).HasColumnType("bit").IsRequired();
            builder.Property(m => m.ApprovedAt).HasColumnType("datetime");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();

            builder.HasKey(m => m.Email);
            builder.ToTable("Subscribers");
        }

    }


}
