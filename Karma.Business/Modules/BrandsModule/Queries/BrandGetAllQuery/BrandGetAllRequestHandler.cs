using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karma.Business.Modules.BrandsModule.Queries.BrandGetAllQuery
{
    internal class BrandGetAllRequestHandler : IRequestHandler<BrandGetAllRequest, IEnumerable<Brand>>
    {
        private readonly IBrandRepository _brandRepository;

        public BrandGetAllRequestHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> Handle(BrandGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = _brandRepository.GetAll(m => m.DeletedBy == null);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
