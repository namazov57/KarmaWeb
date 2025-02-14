﻿using Karma.Infrastructure.Commons.Concretes;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Exceptions;
using Karma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Data.Repositories
{
    class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext db) : base(db) { }

        public async Task<IEnumerable<Brand>> GetBrandsForFilter()
        {
            var brandIds = await this.GetAll(m => m.DeletedBy == null).Select(m => m.BrandId).Distinct().ToArrayAsync();

            return await _db.Set<Brand>().Where(m => brandIds.Contains(m.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Color>> GetColorsForFilter()
        {
            var colorIds = await _db.Set<ProductCatalog>().Select(m => m.ColorId).Distinct().ToArrayAsync();

            return await _db.Set<Color>().Where(m => colorIds.Contains(m.Id)).ToListAsync();
        }

        public IQueryable<ProductImage> GetImages(Expression<Func<ProductImage, bool>> expression = null)
        {
            var query = _db.Set<ProductImage>().AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            return query;
        }

        public async Task<IEnumerable<Material>> GetMaterialsForFilter()
        {
            var materialIds = await _db.Set<ProductCatalog>().Select(m => m.MaterialId).Distinct().ToArrayAsync();

            return await _db.Set<Material>().Where(m => materialIds.Contains(m.Id)).ToListAsync();
        }

        public async Task<IEnumerable<Size>> GetSizesForFilter()
        {
            var sizeIds = await _db.Set<ProductCatalog>().Select(m => m.SizeId).Distinct().ToArrayAsync();

            return await _db.Set<Size>().Where(m => sizeIds.Contains(m.Id)).ToListAsync();
        }

        public IQueryable<ProductCatalog> GetCatalog(Expression<Func<ProductCatalog, bool>> expression = null)
        {
            var query = _db.Set<ProductCatalog>().AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            return query;
        }

        public async Task<Basket> AddToBasketAsync(Basket basket, CancellationToken cancellationToken)
        {
            await _db.Set<Basket>().AddAsync(basket, cancellationToken);
            return basket;
        }

        public async Task<Basket> ChangeBasketQuantityAsync(Basket basket, CancellationToken cancellationToken)
        {
            var entity = await _db.Set<Basket>().FirstOrDefaultAsync(m => m.UserId == basket.UserId && m.CatalogId == basket.CatalogId);

            if (entity is null)
                throw new BadRequestException("BAD_DATA", new Dictionary<string, IEnumerable<string>>
                {
                    [nameof(basket.CatalogId)] = new[] { "Product cant be found!" }
                });

            if (basket.Quantity <= 0)
                throw new BadRequestException("BAD_DATA", new Dictionary<string, IEnumerable<string>>
                {
                    [nameof(basket.Quantity)] = new[] { "Invalid value for Quantity!" }
                });

            entity.Quantity = basket.Quantity;

            await _db.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<string> SetRateAsync(ProductRate rate, CancellationToken cancellationToken)
        {
            var product = this.Get(m => m.Id == rate.ProductId && m.DeletedBy == null);

            var productRate = await _db.Set<ProductRate>().FirstOrDefaultAsync(m => m.ProductId == rate.ProductId && m.UserId == rate.UserId, cancellationToken);

            if (productRate != null)
            {
                productRate.Rate = rate.Rate;
            }
            else
            {
                productRate = rate;
                await _db.Set<ProductRate>().AddAsync(productRate, cancellationToken);
            }

            await _db.SaveChangesAsync(cancellationToken);

            product.Rate = _db.Set<ProductRate>().Where(m => m.ProductId == product.Id).Average(m => m.Rate);
            return product.Rate switch
            {
                var v when v >= 4.8D => "rate-5",
                var v when v > 4D => "rate-half5",
                var v when v >= 3.8D => "rate-4",
                var v when v > 3D => "rate-half4",
                var v when v >= 2.8D => "rate-3",
                var v when v > 2D => "rate-half3",
                var v when v >= 1.8D => "rate-2",
                var v when v > 1D => "rate-half2",
                var v when v >= 0.8D => "rate-1",
                var v when v > 0 => "rate-half1",
                _ => ""
            };
        }

        public async Task<string> GetPriceAsync(ProductCatalog model, CancellationToken cancellationToken)
        {
            var product = this.Get(m => m.Id == model.ProductId);

            var entity = await _db.Set<ProductCatalog>().FirstOrDefaultAsync(m => m.ProductId == product.Id
            && m.SizeId == model.SizeId
            && m.ColorId == model.ColorId
            && m.MaterialId == model.MaterialId
            , cancellationToken);

            if (entity?.Price != null)
                return $"{entity?.Price.Value:0.00}₼";

            return $"{product.Price:0.00}₼"; ;
        }

        public IQueryable<Basket> GetBaseket(int userId)
        {
            return _db.Set<Basket>().Where(m => m.UserId == userId);
        }

        public async Task RemoveFromBasketAsync(Basket basket, CancellationToken cancellationToken)
        {
            var entity = await _db.Set<Basket>().FirstOrDefaultAsync(m => m.UserId == basket.UserId && m.CatalogId == basket.CatalogId, cancellationToken);

            if (entity is null)
                throw new BadRequestException("BAD_DATA", new Dictionary<string, IEnumerable<string>>
                {
                    [nameof(basket.CatalogId)] = new[] { "Product cant be found!" }
                });

            _db.Set<Basket>().Remove(entity);

            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<Order> CreateOrder(Order model, int userId, CancellationToken cancellationToken)
        {



            var details = await (from b in this.GetBaseket(userId)
                                 join pc in this.GetCatalog() on b.CatalogId equals pc.Id
                                 join p in this.GetAll() on pc.ProductId equals p.Id
                                 select new OrderDetail
                                 {
                                     CatalogId = b.CatalogId,
                                     Price = pc.Price == null ? p.Price : pc.Price.Value,
                                     Quantity = b.Quantity
                                 }).ToArrayAsync(cancellationToken);

            model.Amount = details.Sum(m => m.Quantity * m.Price);

            await _db.Set<Order>().AddAsync(model, cancellationToken);
            _db.SaveChanges();
            details = details.Select(m => new OrderDetail
            {
                OrderId = model.Id,
                CatalogId = m.CatalogId,
                Price = m.Price,
                Quantity = m.Quantity
            }).ToArray();

            await _db.Set<OrderDetail>().AddRangeAsync(details, cancellationToken);
            _db.SaveChanges();

            return model;
        }

        public async Task<ProductImage> AddProductImageAsync(int productId, ProductImage image, CancellationToken cancellationToken)
        {
            image.ProductId = productId;

            await _db.Set<ProductImage>().AddAsync(image, cancellationToken);
            return image;
        }

        public async Task<ProductCatalog> AddProductCatalogItemAsync(int productId, ProductCatalog item, CancellationToken cancellationToken)
        {
            item.ProductId = productId;

            await _db.Set<ProductCatalog>().AddAsync(item, cancellationToken);
            return item;
        }

        public void RemoveProductImage(ProductImage image)
        {
            _db.Set<ProductImage>().Remove(image);
        }

        public async Task<ProductCatalog> GetProductCatalogItemByIdAsync(int catalogId, CancellationToken cancellationToken)
        {
            var catalogItem = await this.GetCatalog(m => m.Id == catalogId).FirstOrDefaultAsync(cancellationToken);
            return catalogItem;
        }

        public void RemoveProductCatalogItem(ProductCatalog catalogItem)
        {
            _db.Set<ProductCatalog>().Remove(catalogItem);
        }
    }
}
