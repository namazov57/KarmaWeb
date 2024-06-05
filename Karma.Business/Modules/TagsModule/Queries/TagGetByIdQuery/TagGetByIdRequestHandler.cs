using Karma.Data.Repositories;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Karma.Business.Modules.TagsModule.Queries.TagGetByIdQuery
{
    internal class TagGetByIdRequestHandler : IRequestHandler<TagGetByIdRequest, Tag>
    {
        private readonly ITagRepository tagRepository;

        public TagGetByIdRequestHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public async Task<Tag> Handle(TagGetByIdRequest request, CancellationToken cancellationToken)
        {
            var model = tagRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return model;
        }
    }
}
