using MediatR;

namespace Karma.Business.Modules.ColorsModule.Commands.ColorRemoveCommand
{
    public class ColorRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
