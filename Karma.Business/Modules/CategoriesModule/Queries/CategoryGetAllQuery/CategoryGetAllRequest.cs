using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery
{
    public class CategoryGetAllRequest : IRequest<IEnumerable<Category>>
    {
    }
}
