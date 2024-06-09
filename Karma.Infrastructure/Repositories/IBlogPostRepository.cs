using Karma.Infrastructure.Commons.Abstracts;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Entities;

namespace Karma.Infrastructure.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {

       
        void ResolveTags(BlogPost blogPost,string[] tags);
        IQueryable<Tag> GetTagsByBlogPostId(int id);

        IQueryable<Tag> GetUsedTags();
        BlogPostComment AddComment(int postId,int? parentId,string comment);
        int CommentsCount(int postId);

        IQueryable<BlogPostComment> GetComments(int postId);

       
    }
}
