
using Ganss.Xss;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    internal class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPost>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostAddRequestHandler(IBlogPostRepository blogPostRepository, IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var model = new BlogPost
            {
                Title = request.Title,
                Body = sanitizer.Sanitize(request.Body),
                CategoryId = request.CategoryId
            };

            model.ImagePath = fileService.Upload(request.File);
            model.Slug = fileService.Upload(request.File);

            blogPostRepository.Add(model);
            blogPostRepository.Save();

            blogPostRepository.ResolveTags(model,request.Tags);
            blogPostRepository.Save();

            return model;
           
           
        }
    }
}
