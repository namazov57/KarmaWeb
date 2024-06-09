using Karma.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Services.Concretes
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor ctx;

        public IdentityService(IHttpContextAccessor ctx)
        {
            this.ctx = ctx;
        }
        public int? GetPrincipalId()
        {
            var userIdStr = ctx.HttpContext.User.Claims.FirstOrDefault(m => m.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

            if (string.IsNullOrWhiteSpace(userIdStr))
                return null;


            return Convert.ToInt32(userIdStr);
        }
    }
}
