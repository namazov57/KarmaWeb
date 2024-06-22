using Karma.Business.Modules.DashboardModule.Queries.CountOfStatisticQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Karma.WebUI.ViewComponents
{
    public class CountOfStatisticViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public CountOfStatisticViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await mediator.Send(new CountOfStatisticRequest());
            return View(response);
        }
    }
}
