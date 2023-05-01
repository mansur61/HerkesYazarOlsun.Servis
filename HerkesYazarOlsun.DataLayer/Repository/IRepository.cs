using HerkesYazarOlsun.Model.Entity;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);

        long GetSequneceNextVal(string sequneceName);
    }
}
