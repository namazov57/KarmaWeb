using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Commands.MaterialRemoveCommand
{
    public class MaterialRemoveRequest : IRequest
    {
        public int Id { get; set; }
    }
}
