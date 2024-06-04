using Karma.Infrastructure.Commons.Concretes;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Karma.Data.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(DbContext _db) : base(_db)
        {
        }
    }
}
