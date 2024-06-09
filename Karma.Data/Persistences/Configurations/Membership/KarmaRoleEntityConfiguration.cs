using Karma.Infrastructure.Entites.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Data.Persistences.Configurations.Membership
{
    public class KarmaRoleEntityConfiguration : IEntityTypeConfiguration<KarmaRole>
    {
        public void Configure(EntityTypeBuilder<KarmaRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}
