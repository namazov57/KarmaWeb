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
    public class KarmaUserLoginEntityConfiguration : IEntityTypeConfiguration<KarmaUserLogin>
    {
        public void Configure(EntityTypeBuilder<KarmaUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
