
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public abstract class Base2DbContext : DbContext, IDisposable
    {
        public abstract IList<T> NpSqlQueryDapper<T>(string sql, object[] parameters = null);

    }
}
