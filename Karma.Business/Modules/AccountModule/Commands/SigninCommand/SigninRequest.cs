using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.AccountModule.Commands.SigninCommand
{
    public class SigninRequest:IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
