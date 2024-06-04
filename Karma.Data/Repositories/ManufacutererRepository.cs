using Karma.Infrastructure.Commons.Concretes;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Karma.Data.Repositories
{
    public class ManufacutererRepository : Repository<Manufacturer>, IManufacutererRepository
    {
        public ManufacutererRepository(DbContext _db) : base(_db)
        {
        }
    }
}
