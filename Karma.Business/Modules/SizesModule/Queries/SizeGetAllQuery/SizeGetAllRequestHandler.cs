﻿using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karma.Business.Modules.SizesModule.Queries.SizeGetAllQuery
{
    internal class SizeGetAllRequestHandler : IRequestHandler<SizeGetAllRequest, IEnumerable<Size>>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetAllRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        public async Task<IEnumerable<Size>> Handle(SizeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = sizeRepository.GetAll(m => m.DeletedBy == null);

            return await data.ToListAsync(cancellationToken);
        }
    }
}
