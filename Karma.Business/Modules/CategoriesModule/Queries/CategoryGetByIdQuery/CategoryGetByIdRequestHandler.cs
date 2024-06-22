using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karma.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    internal class CategoryGetByIdRequestHandler : IRequestHandler<CategoryGetByIdRequest, CategoryGetByIdRequestDto>
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryGetByIdRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<CategoryGetByIdRequestDto> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {


            var query = from current in categoryRepository.GetAll(m => m.Id == request.Id && m.DeletedBy == null)
                        join parent in categoryRepository.GetAll()
                        on current.ParentId equals parent.Id into ljCurrent
                        from lj in ljCurrent.DefaultIfEmpty()
                        select new CategoryGetByIdRequestDto
                        {
                            Id = current.Id,
                            Name = current.Name,
                            ParentId = current.ParentId,
                            ParentName = lj.Name,
                        };
            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
