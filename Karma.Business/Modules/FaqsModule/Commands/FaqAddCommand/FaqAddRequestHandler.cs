using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Commands.FaqAddCommand
{
    internal class FaqAddRequestHandler : IRequestHandler<FaqAddRequest, Faq>
    {
        private readonly IFaqRepository faqRepository;

        public FaqAddRequestHandler(IFaqRepository faqRepository)
        {
            this.faqRepository = faqRepository;
        }

        public async Task<Faq> Handle(FaqAddRequest request, CancellationToken cancellationToken)
        {
            var faq = new Faq
            {
                Question = request.Question,
                Answer = request.Answer,
            };

            faqRepository.Add(faq);
            faqRepository.Save();

            return faq;
        }
    }
}
