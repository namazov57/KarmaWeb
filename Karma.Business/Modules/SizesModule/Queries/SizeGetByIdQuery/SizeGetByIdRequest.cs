using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.SizesModule.Queries.SizeGetByIdQuery
{
    public class SizeGetByIdRequest : IRequest<Size>
    {
        public int Id { get; set; }
    }
}
