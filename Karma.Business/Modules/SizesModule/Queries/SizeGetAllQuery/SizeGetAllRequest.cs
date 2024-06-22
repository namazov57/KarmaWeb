using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.SizesModule.Queries.SizeGetAllQuery
{
    public class SizeGetAllRequest : IRequest<IEnumerable<Size>>
    {
    }
}
