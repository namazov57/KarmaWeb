using Karma.Infrastructure.Commons.Abstracts;
using Karma.Infrastructure.Commons.Concretes;
using MediatR;

namespace Karma.Business.Modules.ShopModule.Queries.ProductsGetAllQuery
{
    public class ProductsGetAllRequest : Pageable, IRequest<IPagedResponse<ProductGetAllDto>>
    {
        public override int Size
        {
            get
            {
                return base.Size < 12 ? 12 : base.Size;
            }
            set
            {
                base.Size = value < 12 ? 12 : value;
            }
        }
    }
}
