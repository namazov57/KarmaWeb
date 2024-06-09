﻿using Karma.Infrastructure.Entites;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostEditCommand
{
    public class BlogPostEditRequest :IRequest<BlogPost>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public IFormFile File { get; set; }
        public string[] Tags { get; set; }
    }
}
