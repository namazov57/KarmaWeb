using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karma.Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery
{
    internal class CategoryGetAllRequestHandler : IRequestHandler<CategoryGetAllRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetAllRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = _categoryRepository.GetAll(m => m.DeletedBy == null);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
