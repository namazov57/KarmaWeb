using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.BrandsModule.Queries.BrandGetAllQuery
{
    public class BrandGetAllRequest : IRequest<IEnumerable<Brand>>
    {
    }
}
