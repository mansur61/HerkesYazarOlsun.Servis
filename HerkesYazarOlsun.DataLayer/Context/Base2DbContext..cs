
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public abstract class Base2DbContext : DbContext
    {
        public Base2DbContext(DbContextOptions options) : base(options)
        {
        }
        public abstract IList<T> NpSqlQueryDapper<T>(string sql, object[] parameters = null);

    }
}
