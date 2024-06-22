using Karma.Infrastructure.Entites;

using MediatR;

namespace Karma.Business.Modules.SizesModule.Commands.SizeEditCommand
{
    public class SizeEditRequest : IRequest<Size>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
