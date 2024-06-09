using Karma.Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Karma.Infrastructure.Commons.Concretes
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly DbContext _db;
        private readonly DbSet<T> _table;

        public Repository(DbContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public T Add(T model)
        {
            _table.Add(model);
            Save();

            return model;
        }

        public T Edit(T model)
        {
            _db.Entry(model).State = EntityState.Modified;
            return model;
        }

        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _table.FirstOrDefault();
            }

            var model = _table.FirstOrDefault(predicate);
            return model;

           
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null, bool tracking = true)
        {
            var query = _table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            if (predicate is not null)
                query = query.Where(predicate);

            return query;
        }

        public void Remove(T model)
        {
            _db.Remove(model);
            Save();
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
