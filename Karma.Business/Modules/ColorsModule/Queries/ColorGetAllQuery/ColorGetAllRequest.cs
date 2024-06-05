using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest : IRequest<IEnumerable<Color>>
    {
    }
}
