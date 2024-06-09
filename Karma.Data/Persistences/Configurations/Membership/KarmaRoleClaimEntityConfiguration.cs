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
    public class KarmaRoleClaimEntityConfiguration : IEntityTypeConfiguration<KarmaRoleClaim>
    {
        public void Configure(EntityTypeBuilder<KarmaRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
