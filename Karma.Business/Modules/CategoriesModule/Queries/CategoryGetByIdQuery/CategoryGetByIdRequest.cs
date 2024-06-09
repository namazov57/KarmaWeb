using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdRequest : IRequest<CategoryGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
