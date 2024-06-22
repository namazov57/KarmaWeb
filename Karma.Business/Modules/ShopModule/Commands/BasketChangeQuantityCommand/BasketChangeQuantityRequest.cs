using MediatR;

namespace Karma.Business.Modules.ShopModule.Commands.BasketChangeQuantityCommand
{
    public class BasketChangeQuantityRequest : IRequest<BasketSummary>
    {
        public int CatalogId { get; set; }
        public decimal Quantity { get; set; }
    }
}
