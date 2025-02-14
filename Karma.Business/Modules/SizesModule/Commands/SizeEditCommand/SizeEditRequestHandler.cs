﻿using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.SizesModule.Commands.SizeEditCommand
{
    internal class SizeEditRequestHandler : IRequestHandler<SizeEditRequest, Size>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeEditRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public async Task<Size> Handle(SizeEditRequest request, CancellationToken cancellationToken)
        {
            //automapper
            var size = new Size
            {
                Id = request.Id,
                Name = request.Name,
                ShortName = request.ShortName,
            };

            sizeRepository.Edit(size);
            sizeRepository.Save();

            return size;
        }
    }
}
