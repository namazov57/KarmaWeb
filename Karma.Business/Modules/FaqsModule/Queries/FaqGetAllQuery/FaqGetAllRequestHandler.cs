﻿using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karma.Business.Modules.FaqsModule.Queries.FaqGetAllQuery
{
    internal class FaqGetAllRequestHandler : IRequestHandler<FaqGetAllRequest, IEnumerable<Faq>>
    {
        private readonly IFaqRepository faqRepository;

        public FaqGetAllRequestHandler(IFaqRepository faqRepository)
        {
            this.faqRepository = faqRepository;
        }

        public async Task<IEnumerable<Faq>> Handle(FaqGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = faqRepository.GetAll(m => m.DeletedBy == null);

            return await data.ToListAsync(cancellationToken);
        }
    }
}
