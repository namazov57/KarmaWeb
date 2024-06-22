using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Commands.MaterialEditCommand
{
    public class MaterialEditRequest : IRequest<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
