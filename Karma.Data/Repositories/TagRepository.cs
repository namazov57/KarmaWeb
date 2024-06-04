using Karma.Infrastructure.Commons.Concretes;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Karma.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DbContext _db) : base(_db)
        {
        }
    }
}
