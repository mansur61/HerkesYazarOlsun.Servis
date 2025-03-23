using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.DataLayer.Repo; 
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HerkesYazaOlsunContext _dbContext;

        public UnitOfWork() { _dbContext = new HerkesYazaOlsunContext(); }
        public UnitOfWork(HerkesYazaOlsunContext context) { _dbContext = context; }

        #region IUnitOfWork 
        public IRepository<T> GetRepository<T>() where T : BaseEntity => new Repository<T>(_dbContext);
        public IRepo<T> Repo<T>() where T : NewBaseEntity => new Repo<T>(_dbContext);

        public int Save()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return _dbContext.SaveChanges();
            }
            catch
            {
                // Burada DbEntityValidationException hatalarını handle edebiliriz.
                throw;
            }
        }

        public IList<T> ExecuteQuery<T>(string sql)
        {
            var result = _dbContext.NpSqlQueryDapper<T>(sql).ToList();
            return result;
        }

        public int ExecuteSqlCommand(string sql)
        {
            var result = _dbContext.Database.ExecuteSqlRaw(sql);
            return result;
        }

      
        #endregion

        #region Transaction

        public void CloseTransaction()
        {
            throw new NotImplementedException();
        }

        public void OpenTransaction()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    
    }
}
