using Karma.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Queries.TagsGetUsedQuery
{
    public class TagsGetUsedRequest:IRequest<IEnumerable<Tag>>
    {
    }
}
