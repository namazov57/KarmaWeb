using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Queries.FaqGetByIdQuery
{
    internal class FaqGetByIdRequestHandler : IRequestHandler<FaqGetByIdRequest, Faq>
    {
        private readonly IFaqRepository faqRepository;

        public FaqGetByIdRequestHandler(IFaqRepository faqRepository)
        {
            this.faqRepository = faqRepository;
        }
        public async Task<Faq> Handle(FaqGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = faqRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return data;
        }
    }
}
