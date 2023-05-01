using HerkesYazarOlsun.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
