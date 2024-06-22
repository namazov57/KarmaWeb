using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;

namespace Karma.Business.Modules.ShopModule.Commands.CreateOrderCommand
{
    class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, Order>
    {
        private readonly IProductRepository productRepository;
        private readonly IIdentityService identityService;

        public CreateOrderRequestHandler(IProductRepository productRepository, IIdentityService identityService)
        {
            this.productRepository = productRepository;
            this.identityService = identityService;
        }
        public async Task<Order> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ShippingAddress = request.ShippingAddress,
                ShippingCity = request.ShippingCity,
                ShippingCountry = request.ShippingCountry,
                Phone = request.Phone,
                CouponCode = request.CouponCode,
                Postcode = request.Postcode,
                Email = request.Email,
            };

            return await productRepository.CreateOrder(order, identityService.GetPrincipalId().Value, cancellationToken);            
        }
    }
}
