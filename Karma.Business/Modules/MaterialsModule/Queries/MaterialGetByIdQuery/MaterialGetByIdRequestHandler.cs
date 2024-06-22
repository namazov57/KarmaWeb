using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Queries.MaterialGetByIdQuery
{
    internal class MaterialGetByIdRequestHandler : IRequestHandler<MaterialGetByIdRequest, Material>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialGetByIdRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }
        public async Task<Material> Handle(MaterialGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = materialRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return data;
        }
    }
}
