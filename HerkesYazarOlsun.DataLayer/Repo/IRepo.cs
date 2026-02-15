using HerkesYazarOlsun.Model.Entity;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public interface IRepo<T> where T : NewBaseEntity
    {
        List<T> GetAll();
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllQueryable();

        IQueryable<T> GetAllQueryableNoTracking(Expression<Func<T, bool>> predicate);

        T Get(long id);
        T Add(T entity, long tcNo);
        T Ekle(T entity, string mail);
        T Update(T entity, long tcNo);
        T Guncelle(T entity, string mail);
        void Sil(int id, string mail);
        void Delete(T entity, long tcNo);
        long GetSequneceNextVal(string sequneceName);
    }
}
