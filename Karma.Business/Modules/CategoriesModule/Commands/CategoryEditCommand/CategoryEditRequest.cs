using Karma.Infrastructure.Entites;
using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    public class CategoryEditRequest : IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

    }
}
