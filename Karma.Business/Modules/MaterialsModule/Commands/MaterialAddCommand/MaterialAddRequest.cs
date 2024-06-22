using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Commands.MaterialAddCommand
{
    public class MaterialAddRequest : IRequest<Material>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
