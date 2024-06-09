using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Services.Abstracts
{
    public interface IIdentityService
    {
        int? GetPrincipalId();
    }
}
