using Karma.Infrastructure.Commons.Concretes;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Entities;
using Karma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Karma.Data.Repositories
{
    internal class BlogPostRepository : Repository<BlogPost>,IBlogPostRepository
    {
        public BlogPostRepository(DbContext db) : base(db)
        {
        }

         BlogPostTag AddTag(int blogPostId, string tag)
        {
           var tagsTable =_db.Set<Tag>();
           var blogPostTagsTable =_db.Set<BlogPostTag>();

            var tagEntity=tagsTable.FirstOrDefault(m => m.Name.Equals(tag));
            if(tagEntity== null)
            {
                tagEntity = new Tag { Name = tag, };
                tagsTable.Add(tagEntity);
                _db.SaveChanges();
            }

            var blogPostTag = blogPostTagsTable.Where(m => m.TagId == tagEntity.Id && m.BlogPostId==blogPostId).FirstOrDefault();

            if(blogPostTag == null)
            {
                blogPostTag = new BlogPostTag
                {
                    TagId = tagEntity.Id,
                    BlogPostId = blogPostId
                };
                blogPostTagsTable.Add(blogPostTag);
            }
            return blogPostTag;
        }

        public void ResolveTags(BlogPost blogPost, string[] tags)
        {
           if(tags ==null || tags.Length==0) return;

            var tagsTable = _db.Set<Tag>();
            var blogPostTagsTable = _db.Set<BlogPostTag>();

            var assignedTagsQuery = from bpt in blogPostTagsTable
                               join t in tagsTable on bpt.TagId equals t.Id
                               where bpt.BlogPostId == blogPost.Id
                               select new
                               {
                                   TagId = bpt.TagId,
                                   BlogPostId = bpt.BlogPostId,
                                   Text=t.Name,
                                   BlogPostTag = bpt

                               };

            var forDeletion=assignedTagsQuery.Where(m=> !tags.Contains(m.Text)).Select(m=> m.BlogPostTag).ToList();

            blogPostTagsTable.RemoveRange(forDeletion);

            var forInsertion = tags.Except(assignedTagsQuery.Select(m=>m.Text).ToList());

            foreach (var tag in forInsertion)
            {
                AddTag(blogPost.Id,tag);
            }

        }

        public IQueryable<Tag> GetTagsByBlogPostId(int id)
        {
            var query = from bpt in _db.Set<BlogPostTag>()
                        join t in _db.Set<Tag>() on bpt.TagId equals t.Id
                        where bpt.BlogPostId == id
                        select t;

            return query;

        }

        public IQueryable<Tag> GetUsedTags()
        {
            var query = (from bpt in _db.Set<BlogPostTag>()
                         join t in _db.Set<Tag>() on bpt.TagId equals t.Id
                         select t).Distinct();

            return query;
        }

        public BlogPostComment AddComment(int postId, int? parentId, string comment)
        {
            var commentsTable = _db.Set<BlogPostComment>();

            var commentEntity = new BlogPostComment
            {
                PostId = postId,
                ParentId = parentId,
                Comment = comment
            };

            commentsTable.Add(commentEntity);
            return commentEntity;
        }

        public int CommentsCount(int postId)
        {
            return _db.Set<BlogPostComment>().Count(m => m.PostId == postId && m.DeletedBy == null);
        }

        public IQueryable<BlogPostComment> GetComments(int postId)
        {
            return _db.Set<BlogPostComment>().Where(m => m.PostId == postId && m.DeletedBy == null);
        }
    }
}
