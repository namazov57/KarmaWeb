using Karma.Infrastructure.Commons.Abstracts;
using Karma.Infrastructure.Commons.Concretes;
using MediatR;

namespace Karma.Business.Modules.ShopModule.Queries.ComplexFilterQuery
{
    public class ComplexFilterRequest : Pageable, IRequest<IPagedResponse<ComplexFilterResponseDto>>
    {
        public int[] Brands { get; set; }
        public int[] Colors { get; set; }
        public int[] Materials { get; set; }
        public int[] Sizes { get; set; }
        public ComplexFilterPrice Price { get; set; }
    }
}
