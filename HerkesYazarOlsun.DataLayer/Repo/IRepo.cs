using HerkesYazarOlsun.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public interface IRepo<T> where T : NewBaseEntity
    {
        List<T> GetAll();
        IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllQueryable();
        T Get(long id);
        T Add(T entity, long tcNo);
        T Update(T entity, long tcNo);
        void Delete(int id, long tcNo);
        void Delete(T entity, long tcNo);
        long GetSequneceNextVal(string sequneceName);
    }
}
