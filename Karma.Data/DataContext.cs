using Karma.Infrastructure.Commons.Abstracts;
using Karma.Infrastructure.Entites.Membership;
using Karma.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Karma.Data
{
    public class DataContext:IdentityDbContext<KarmaUser, KarmaRole, int, KarmaUserClaim, KarmaUserRole, KarmaUserLogin, KarmaRoleClaim, KarmaUserToken>
    {
        private readonly IDateTimeServive dateTimeService;
        private readonly IIdentityService identityService;
        public DataContext(DbContextOptions options, IDateTimeServive dateTimeService, IIdentityService identityService)
            : base(options)
        {
            this.dateTimeService = dateTimeService;
           
            this.identityService = identityService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();

            if (changes != null)
            {
                foreach (var entry in changes.Where(m => m.State == EntityState.Added || m.State == EntityState.Modified || m.State == EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = identityService.GetPrincipalId();
                            entry.Entity.CreatedAt = dateTimeService.ExecutingTime;
                            break;
                        case EntityState.Modified:
                            entry.Entity.ModifiedBy = identityService.GetPrincipalId();
                            entry.Entity.ModifiedAt = dateTimeService.ExecutingTime;

                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedBy = identityService.GetPrincipalId();
                            entry.Entity.DeletedAt = dateTimeService.ExecutingTime;

                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            entry.Property(m => m.ModifiedBy).IsModified = false;
                            entry.Property(m => m.ModifiedAt).IsModified = false;
                            break;
                        default:
                            break;
                    }
                }
            }


            return base.SaveChanges();
        }










    }
}
