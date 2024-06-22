using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.FaqsModule.Commands.FaqEditCommand
{
    public class FaqEditRequest : IRequest<Faq>
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
