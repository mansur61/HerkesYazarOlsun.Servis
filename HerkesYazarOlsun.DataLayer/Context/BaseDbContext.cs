
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer.Context
{
   
    public abstract class BaseDbContext : DbContext, IDisposable
    {

        public abstract IList<T> SqlQueryDapper<T>(string sql, object[] parameters = null);
    }
}
