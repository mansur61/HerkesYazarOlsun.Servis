
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Context
{
   
    public abstract class BaseSqlDbContext : DbContext, IDisposable
    {
        public BaseSqlDbContext(DbContextOptions options) : base(options)
        {
        }
        public abstract IList<T> SqlQueryDapper<T>(string sql, object[] parameters = null);
    }
}
