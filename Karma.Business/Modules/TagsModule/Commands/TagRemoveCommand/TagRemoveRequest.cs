using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.TagsModule.Commands.TagRemoveCommand
{
    public class TagRemoveRequest:IRequest
    {
        public byte Id { get; set; }
    }
}
