using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Karma.Business.Modules.TagsModule.Queries.TagGetAllQuery
{
    internal class TagGetAllRequestHandler : IRequestHandler<TagGetAllRequest, IEnumerable<Tag>>
    {
        private readonly ITagRepository tagRepository;

        public TagGetAllRequestHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public async Task<IEnumerable<Tag>> Handle(TagGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = tagRepository.GetAll(m => m.DeletedBy == null);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
