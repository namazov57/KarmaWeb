using Karma.Infrastructure.Commons.Abstracts;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Entites.Membership;
using Karma.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Karma.Data
{
    public class DataContext:IdentityDbContext<KarmaUser, KarmaRole, int, KarmaUserClaim, KarmaUserRole, KarmaUserLogin, KarmaRoleClaim, KarmaUserToken>
    {
        private readonly IDateTimeServive _dateTimeServive;
        private readonly IIdentityService _identityService;

        public DataContext(DbContextOptions options,
            IDateTimeServive dateTimeServive,
            IIdentityService identityService
            ):base(options)
        {
            _dateTimeServive = dateTimeServive;
            _identityService = identityService;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {
            var changes =this.ChangeTracker.Entries<IAuditableEntity>();
            if(changes !=null)
            {
                foreach (var entity in changes
                    .Where(ch => ch.State == EntityState.Added ||
                    ch.State ==EntityState.Deleted || 
                    ch.State ==EntityState.Modified))
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            entity.Entity.CreatedBy = _identityService.GetPrincipalId();
                            entity.Entity.CreatedAt = _dateTimeServive.ExecutingTime;
                            break;
                       
                        case EntityState.Modified:
                            entity.Entity.ModifiedBy = _identityService.GetPrincipalId();
                            entity.Entity.ModifiedAt = _dateTimeServive.ExecutingTime;

                            entity.Property(m => m.CreatedBy).IsModified = false;
                            entity.Property(m => m.CreatedAt).IsModified = false;
                            break;
                        case EntityState.Deleted:
                            entity.State = EntityState.Modified;
                            entity.Entity.DeletedBy = _identityService.GetPrincipalId();
                            entity.Entity.DeletedAt = _dateTimeServive.ExecutingTime;

                            entity.Property(m => m.CreatedBy).IsModified = false;
                            entity.Property(m => m.CreatedAt).IsModified = false;
                            entity.Property(m => m.ModifiedBy).IsModified = false;
                            entity.Property(m => m.ModifiedAt).IsModified = false;
                            break;


                        default:
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Brand> Manufacturers { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }







    }
}
