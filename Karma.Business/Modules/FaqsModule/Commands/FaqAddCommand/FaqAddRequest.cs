using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Commands.FaqAddCommand
{
    public class FaqAddRequest : IRequest<Faq>
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
