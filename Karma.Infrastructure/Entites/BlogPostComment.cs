using Karma.Infrastructure.Commons;

namespace Karma.Infrastructure.Entities
{
    public class BlogPostComment : BaseEntity<int> 
    { 
        public int PostId { get; set; }
        public int? ParentId { get; set; }
        public string Comment { get; set; }
    }
}
