﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.BlogPostModule.Commands.BlogPostAddCommentCommand
{
    public class BlogPostCommentDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
