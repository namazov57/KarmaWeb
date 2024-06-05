using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    internal class BrandGetByIdRequestHandler : IRequestHandler<BrandGetByIdRequest, Brand>
    {
        private readonly IBrandRepository _brandRepository;
        public BrandGetByIdRequestHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(BrandGetByIdRequest request, CancellationToken cancellationToken)
        {
            var model = _brandRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return model;
        }
    }
}
