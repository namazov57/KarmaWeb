using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Queries.FaqGetByIdQuery
{
    public class FaqGetByIdRequest : IRequest<Faq>
    {
        public int Id { get; set; }
    }
}
