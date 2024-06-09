using Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommentCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Queries.BlogPostCommentsQuery
{
    public class BlogPostCommentsRequest : IRequest<IEnumerable<BlogPostCommentDto>>
    {
        public int PostId { get; set; }
    }
}
