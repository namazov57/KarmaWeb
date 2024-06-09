using Karma.Infrastructure.Entites.Membership;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.AccountModule.Commands.SigninCommand
{
    public class SigninRequest : IRequest<KarmaUser>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
