using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Queries.FaqGetAllQuery
{
    public class FaqGetAllRequest : IRequest<IEnumerable<Faq>>
    {
    }
}
