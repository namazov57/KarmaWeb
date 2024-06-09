using Karma.Infrastructure.Entites.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.AccountModule.Commands.BindClaimsCommand
{

    internal class BindClaimsRequestHandler : IRequestHandler<BindClaimsRequest>
    {
        private readonly DbContext db;
        private readonly UserManager<KarmaUser> userManager;

        public BindClaimsRequestHandler(DbContext db, UserManager<KarmaUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task Handle(BindClaimsRequest request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(request.Identity.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value);

            var user = await db.Set<KarmaUser>().FirstOrDefaultAsync(m => m.Id == userId, cancellationToken);

            request.Identity.AddClaim(new Claim(ClaimTypes.GivenName, $"{user.Name} {user.Surname}"));


            var roles = await userManager.GetRolesAsync(user);

            foreach (var roleName in roles)
            {
                request.Identity.AddClaim(new Claim(ClaimTypes.Role, roleName));
            }

            var claims = await (from uc in db.Set<KarmaUserClaim>()
                                where uc.UserId == userId && uc.ClaimValue.Equals("1")
                                select uc.ClaimType)
                         .Union(from rc in db.Set<KarmaRoleClaim>()
                                join ur in db.Set<KarmaUserRole>() on rc.RoleId equals ur.RoleId
                                where ur.UserId == userId && rc.ClaimValue.Equals("1")
                                select rc.ClaimType)
                         .Distinct()
                         .ToArrayAsync(cancellationToken);


            foreach (var claimName in claims)
            {
                request.Identity.AddClaim(new Claim(claimName, "1"));
            }
        }
    }
}
