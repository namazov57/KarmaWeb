using System.Linq.Expressions;

namespace Karma.Infrastructure.Commons.Abstracts
{
    public interface IRepository<T>
        where T:class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate = null);
        T Add(T model);
        T Edit(T model);
        void Remove(T model);
        int Save();
    }
}
