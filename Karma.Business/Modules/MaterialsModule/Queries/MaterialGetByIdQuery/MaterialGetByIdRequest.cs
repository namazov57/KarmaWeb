using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Queries.MaterialGetByIdQuery
{
    public class MaterialGetByIdRequest : IRequest<Material>
    {
        public int Id { get; set; }
    }
}
