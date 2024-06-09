using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Commands.CategoryRemoveCommand
{
    public class CategoryRemoveRequest : IRequest
    {
        public byte Id { get; set; }
    }
}
