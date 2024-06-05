using Karma.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.TagsModule.Commands.TagAddCommand
{
    public class TagAddRequest:IRequest<Tag>
    {
        public string Name { get; set; }
    }
}
