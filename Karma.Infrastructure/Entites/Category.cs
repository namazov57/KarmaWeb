



using Karma.Infrastructure.Commons;

namespace Karma.Infrastructure.Entites
{
    public class Category:BaseEntity<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
