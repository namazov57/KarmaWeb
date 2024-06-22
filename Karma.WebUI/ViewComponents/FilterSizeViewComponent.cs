using Karma.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.ViewComponents
{
    public class FilterSizeViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;
        public FilterSizeViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await productRepository.GetSizesForFilter();
            return View(items);
        }
    }
}
