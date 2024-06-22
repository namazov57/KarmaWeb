using MediatR;

namespace Karma.Business.Modules.ShopModule.Commands.RemoveFromBasketCommand
{
    public class RemoveFromBasketRequest : IRequest<BasketSummary>
    {
        public int CatalogId { get; set; }
    }
}
