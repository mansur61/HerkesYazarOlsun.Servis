
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Context
{
    public abstract class BaseNpSqlDbContext : DbContext, IDisposable
    {        
        protected BaseNpSqlDbContext() { }
        protected BaseNpSqlDbContext(DbContextOptions options) : base(options) { }
        public abstract IList<T> NpSqlQueryDapper<T>(string sql, object[] parameters = null);
 
    }
}
