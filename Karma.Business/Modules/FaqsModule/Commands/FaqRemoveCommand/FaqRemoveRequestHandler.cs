using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Commands.FaqRemoveCommand
{
    internal class FaqRemoveRequestHandler : IRequestHandler<FaqRemoveRequest>
    {
        private readonly IFaqRepository faqRepository;

        public FaqRemoveRequestHandler(IFaqRepository faqRepository)
        {
            this.faqRepository = faqRepository;
        }
        public async Task Handle(FaqRemoveRequest request, CancellationToken cancellationToken)
        {
            var faq = faqRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
            faqRepository.Remove(faq);
            faqRepository.Save();
        }
    }
}
