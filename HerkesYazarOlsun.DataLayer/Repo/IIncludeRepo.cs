using HerkesYazarOlsun.Model.Entity;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public interface IIncludeRepo<T> where T : NewBaseEntity
    {
        List<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes);
    }
}
