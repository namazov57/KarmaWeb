using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    public class BrandGetByIdRequest : IRequest<Brand>
    {
        public int Id { get; set; }
    }
}
