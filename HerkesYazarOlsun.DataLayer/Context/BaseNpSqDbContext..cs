
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public abstract class BaseNpSqlDbContext : DbContext, IDisposable
    {
       

        public abstract IList<T> NpSqlQueryDapper<T>(string sql, object[] parameters = null);

        //public static implicit operator BaseNpSqlDbContext(HerkesYazaOlsunContext v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
