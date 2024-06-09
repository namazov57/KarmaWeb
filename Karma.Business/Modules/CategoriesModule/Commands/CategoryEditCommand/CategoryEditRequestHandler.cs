using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Extensions;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    internal class CategoryEditRequestHandler : IRequestHandler<CategoryEditRequest, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryEditRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(CategoryEditRequest request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = request.Id,
                Name = request.Name,
                ParentId=request.ParentId
            };

           if(request.ParentId != null)
            {
                var chilDetect = categoryRepository.GetAll(tracking: false).GetHierarchy(category).Any(m => m.Id ==request.ParentId);
           
                if(chilDetect)
                {
                    category.ParentId = null;
                }
            
            }
            categoryRepository.Edit(category);
            categoryRepository.Save();
            return category;
        }
    }
}
