using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostPublishCommand
{
    internal class BlogPostPublishRequestHandler : IRequestHandler<BlogPostPublishRequest>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IDateTimeServive dateTimeServive;
        private readonly IIdentityService identityService;

        public BlogPostPublishRequestHandler(IBlogPostRepository blogPostRepository, IDateTimeServive dateTimeServive, IIdentityService identityService)
        {
            this.blogPostRepository = blogPostRepository;
            this.dateTimeServive = dateTimeServive;
            this.identityService = identityService;
        }

        public async Task Handle(BlogPostPublishRequest request, CancellationToken cancellationToken)
        {
            var entity = blogPostRepository.Get(m => m.Id == request.PostId && m.DeletedAt == null);

            if (entity.PublishedAt != null)
                throw new Exception("Bu qeyd artiq paylasilib");

            entity.PublishedAt = dateTimeServive.ExecutingTime;
            entity.PublishedBy = identityService.GetPrincipalId();
            blogPostRepository.Save();
        }
    }
}
