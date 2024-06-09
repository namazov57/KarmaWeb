using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.SubscribeModule.Commands.SubscribeTicketCommand
{
    public class SubscribeTicketRequest : IRequest
    {
        public string Email { get; set; }
    }
}
