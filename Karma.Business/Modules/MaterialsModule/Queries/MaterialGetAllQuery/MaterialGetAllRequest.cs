using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.MaterialsModule.Queries.MaterialGetAllQuery
{
    public class MaterialGetAllRequest : IRequest<IEnumerable<Material>>
    {
    }
}
