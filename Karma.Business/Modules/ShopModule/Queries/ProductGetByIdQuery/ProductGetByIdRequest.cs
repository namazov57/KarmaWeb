using MediatR;

namespace Karma.Business.Modules.ShopModule.Queries.ProductGetByIdQuery
{
    public class ProductGetByIdRequest : IRequest<ProductGetByIdDto>
    {
        public int Id { get; set; }
    }
}
