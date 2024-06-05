using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.BrandsModule.Commands.BrandAddCommand
{
    public class BrandAddRequest : IRequest<Brand>
    {
        public string Name { get; set; }
    }
}
