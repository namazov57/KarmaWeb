using Ganss.Xss;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostEditCommand
{
    internal class BlogPostEditRequestHandler : IRequestHandler<BlogPostEditRequest, BlogPost>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostEditRequestHandler(IBlogPostRepository blogPostRepository,IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostEditRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var currentEntity=blogPostRepository.Get(m => m.Id == request.Id && m.DeletedBy==null);

            currentEntity.Title=request.Title;
            currentEntity.Body = sanitizer.Sanitize(request.Body);
            currentEntity.CategoryId=request.CategoryId;
             currentEntity.ImagePath = fileService.ChangeFile(request.File,currentEntity.ImagePath);

            blogPostRepository.ResolveTags(currentEntity, request.Tags);
            blogPostRepository.Save();

            return currentEntity;

        }
    }
}
