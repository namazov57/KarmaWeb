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
    public class KarmaUserRoleEntityConfiguration : IEntityTypeConfiguration<KarmaUserRole>
    {
        public void Configure(EntityTypeBuilder<KarmaUserRole> builder)
        {
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
