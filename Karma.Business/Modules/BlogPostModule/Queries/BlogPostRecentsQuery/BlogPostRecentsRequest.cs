using Karma.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Queries.BlogPostRecentsQuery
{
    public class BlogPostRecentsRequest : IRequest<IEnumerable<BlogPost>>
    {
        public int Size { get; set; }
    }
}
