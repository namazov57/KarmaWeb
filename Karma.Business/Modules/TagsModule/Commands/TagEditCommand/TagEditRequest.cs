using Karma.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.TagsModule.Commands.TagEditCommand
{
    public class TagEditRequest:IRequest<Tag>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
