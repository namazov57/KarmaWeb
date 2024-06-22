using Karma.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.ViewComponents
{
    public class FilterColorViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;
        public FilterColorViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await productRepository.GetColorsForFilter();
            return View(items);
        }
    }
}
