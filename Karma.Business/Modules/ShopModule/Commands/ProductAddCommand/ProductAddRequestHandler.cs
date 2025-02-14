﻿using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;

namespace Karma.Business.Modules.ShopModule.Commands.ProductAddCommand
{
    internal class ProductAddRequestHandler : IRequestHandler<ProductAddRequest, Product>
    {
        private readonly IProductRepository productRepository;
        private readonly IFileService fileService;

        public ProductAddRequestHandler(IProductRepository productRepository, IFileService fileService)
        {
            this.productRepository = productRepository;
            this.fileService = fileService;
        }
        public async Task<Product> Handle(ProductAddRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                StockKeepingUnit = request.StockKeepingUnit,
                Price = request.Price,
                ShortDescription = request.ShortDescription,
                Description = request.Description,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
            };

            product = productRepository.Add(product);
            productRepository.Save();

            

            if (request.Images != null && request.Images.Length > 0)
            {
                foreach (var image in request.Images)
                {
                    var productImage = new ProductImage
                    {
                        IsMain = request.Images[0].IsMain,
                        Name = fileService.Upload(image.File)
                    };

                    await productRepository.AddProductImageAsync(product.Id, productImage, cancellationToken);
                }
                productRepository.Save();
            }

            if (request.Catalog != null && request.Catalog.Length > 0)
            {
                foreach (var item in request.Catalog)
                {
                    await productRepository.AddProductCatalogItemAsync(product.Id, item, cancellationToken);
                }
                productRepository.Save();
            }


            return product;
        }
    }
}
