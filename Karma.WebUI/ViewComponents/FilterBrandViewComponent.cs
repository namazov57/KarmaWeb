using Karma.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.ViewComponents
{
    public class FilterBrandViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;
        public FilterBrandViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await productRepository.GetBrandsForFilter();
            return View(items);
        }
    }
}
