﻿using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Commands.MaterialAddCommand
{
    internal class MaterialAddRequestHandler : IRequestHandler<MaterialAddRequest, Material>
    {
        private readonly IMaterialRepository materialRepository;

        public MaterialAddRequestHandler(IMaterialRepository materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task<Material> Handle(MaterialAddRequest request, CancellationToken cancellationToken)
        {
            var material = new Material
            {
                Name = request.Name,
            };

            materialRepository.Add(material);
            materialRepository.Save();

            return material;
        }
    }
}
