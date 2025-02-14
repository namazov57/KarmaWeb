﻿using Karma.Business.Modules.ShopModule.Commands;
using Karma.Business.Modules.ShopModule.Commands.RemoveFromBasketCommand;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Business.Modules.ShopModule.Commands.RemoveFromBasketCommand
{
    class RemoveFromBasketRequestHandler : IRequestHandler<RemoveFromBasketRequest, BasketSummary>
    {
        private readonly IProductRepository productRepository;
        private readonly IIdentityService identityService;

        public RemoveFromBasketRequestHandler(IProductRepository productRepository, IIdentityService identityService)
        {
            this.productRepository = productRepository;
            this.identityService = identityService;
        }
        public async Task<BasketSummary> Handle(RemoveFromBasketRequest request, CancellationToken cancellationToken)
        {
            var basket = new Basket
            {
                UserId = identityService.GetPrincipalId().Value,
                CatalogId = request.CatalogId
            };

            await productRepository.RemoveFromBasketAsync(basket, cancellationToken);

            var summary = await (from b in productRepository.GetBaseket(identityService.GetPrincipalId().Value)
                                 join pc in productRepository.GetCatalog() on b.CatalogId equals pc.Id
                                 join p in productRepository.GetAll() on pc.ProductId equals p.Id
                                 select new
                                 {
                                     b.Quantity,
                                     Price = pc.Price == null ? p.Price : pc.Price.Value
                                 })
                         .GroupBy(m => 1)
                         .Select(m => new BasketSummary
                         {
                             Count = m.Count(),
                             Total = m.Sum(x => x.Quantity * x.Price)
                         })
                         .FirstOrDefaultAsync(cancellationToken);

            return summary ?? new();
        }
    }
}
