using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.BrandsModule.Commands.BrandEditCommand
{
    public class BrandEditRequest : IRequest<Brand>
    {
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}
