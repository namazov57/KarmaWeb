﻿using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    internal class CategoryAddRequestHandler : IRequestHandler<CategoryAddRequest, Category>
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryAddRequestHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                ParentId= request.ParentId,
            };

            categoryRepository.Add(category);
            categoryRepository.Save();
            return category;
        }
    }
}
