using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    public class CategoryAddRequest : IRequest<Category>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
