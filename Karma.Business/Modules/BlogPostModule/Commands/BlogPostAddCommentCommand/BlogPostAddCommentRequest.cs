using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommentCommand
{
    public class BlogPostAddCommentRequest : IRequest<BlogPostCommentDto>
    {
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public string Comment { get; set; }
    }
}
