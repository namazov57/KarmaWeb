using Karma.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.TagsModule.Commands.TagRemoveCommand
{
    internal class TagRemoveRequestHandler : IRequestHandler<TagRemoveRequest>
    {
        private readonly ITagRepository tagRepository;

        public TagRemoveRequestHandler(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        public async Task Handle(TagRemoveRequest request, CancellationToken cancellationToken)
        {
            var tag = tagRepository.Get(m => m.Id == request.Id && m.DeletedBy==null);

            tagRepository.Remove(tag);
            tagRepository.Save();
        }
    }
}
