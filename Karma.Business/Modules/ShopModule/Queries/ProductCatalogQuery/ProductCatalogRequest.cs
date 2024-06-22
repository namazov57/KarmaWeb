using MediatR;

namespace Karma.Business.Modules.ShopModule.Queries.ProductCatalogQuery
{
    public class ProductCatalogRequest : IRequest<ProductCatalogResponse>
    {
        public int ProductId { get; set; }
    }
}
