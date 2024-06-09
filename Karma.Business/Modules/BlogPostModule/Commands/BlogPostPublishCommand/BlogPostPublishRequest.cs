using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostPublishCommand
{
    public class BlogPostPublishRequest : IRequest
    {
        public int PostId { get; set; }
    }
}
