using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.SizesModule.Commands.SizeAddCommand
{
    public class SizeAddRequest : IRequest<Size>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
