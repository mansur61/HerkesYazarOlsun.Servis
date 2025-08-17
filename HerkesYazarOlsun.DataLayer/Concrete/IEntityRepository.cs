using HerkesYazarOlsun.Model;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        long GetSequneceNextVal(string sequence);
    }
}
