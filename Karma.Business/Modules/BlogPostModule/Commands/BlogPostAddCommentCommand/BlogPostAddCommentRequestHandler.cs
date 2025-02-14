﻿using Karma.Infrastructure.Entites.Membership;
using Karma.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommentCommand
{
    internal class BlogPostAddCommentRequestHandler : IRequestHandler<BlogPostAddCommentRequest, BlogPostCommentDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly UserManager<KarmaUser> userManager;

        public BlogPostAddCommentRequestHandler(IBlogPostRepository blogPostRepository, UserManager<KarmaUser> userManager)
        {
            this.blogPostRepository = blogPostRepository;
            this.userManager = userManager;
        }
        public async Task<BlogPostCommentDto> Handle(BlogPostAddCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = blogPostRepository.AddComment(request.PostId, request.ParentId, request.Comment);
            blogPostRepository.Save();

            var user = await userManager.Users.FirstOrDefaultAsync(m => m.Id == comment.CreatedBy, cancellationToken);

            var response = new BlogPostCommentDto
            {
                Id = comment.Id,
                PostId = comment.PostId,
                ParentId = comment.ParentId,
                Comment = comment.Comment,
                CreatedAt = comment.CreatedAt,
                Author = $"{user.Name} {user.Surname}",
            };
            return response;
        }
    }
}
