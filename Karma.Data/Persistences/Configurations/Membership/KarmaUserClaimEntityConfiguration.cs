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
    public class KarmaUserClaimEntityConfiguration : IEntityTypeConfiguration<KarmaUserClaim>
    {
        public void Configure(EntityTypeBuilder<KarmaUserClaim> builder)
        {
            builder.ToTable("UserClaims", "Membership");
        }
    }
}
