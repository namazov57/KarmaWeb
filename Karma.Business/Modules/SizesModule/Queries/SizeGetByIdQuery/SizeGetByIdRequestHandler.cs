using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.SizesModule.Queries.SizeGetByIdQuery
{
    internal class SizeGetByIdRequestHandler : IRequestHandler<SizeGetByIdRequest, Size>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetByIdRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public async Task<Size> Handle(SizeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = sizeRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return data;
        }
    }
}
