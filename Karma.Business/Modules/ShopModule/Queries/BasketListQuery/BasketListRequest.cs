using MediatR;

namespace Karma.Business.Modules.ShopModule.Queries.BasketListQuery
{
    public class BasketListRequest : IRequest<IEnumerable<BasketListItem>>
    {
    }
}
