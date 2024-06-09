using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.AccountModule.Commands.BindClaimsCommand
{
    public class BindClaimsRequest : IRequest
    {
        public ClaimsIdentity Identity { get; set; }
    }
}
