using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.BrandsModule.Commands.BrandAddCommand
{
    internal class BrandAddRequestHandler : IRequestHandler<BrandAddRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;
        public BrandAddRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(BrandAddRequest request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Name = request.Name
            };

            brandRepository.Add(brand);
            brandRepository.Save();
            return brand;
        }
    }
}
