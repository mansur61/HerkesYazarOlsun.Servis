using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.DataLayer.Repository;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.DataLayer
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;

        // Repository instance cache (isteğe bağlı)
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        // Generic repository seçimi DbContext tipine göre (örnek)
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (IRepository<T>)_repositories[typeof(T)];

            IRepository<T> repo;

            if (_dbContext is HerkesYazaOlsunContext)
            {
                repo = new RepositorySql<T>((SqlServerContext)_dbContext);
            }
            else if (_dbContext is HerkesYazaOlsunContext)
            {
                repo = new RepositoryNpgsql<T>((HerkesYazaOlsunContext)_dbContext);
            }
            else
            {
                throw new NotSupportedException("DbContext tipi desteklenmiyor.");
            }

            _repositories[typeof(T)] = repo;
            return repo;
        }

        // Save işlemi
        public int Save()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // Burada loglama ya da özel hata yönetimi yapılabilir
                throw;
            }
        }
         
        public int ExecuteSqlCommand(string sql)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql);
        }

        // Transaction örnekleri (gerektiğinde implement et)
        public void OpenTransaction()
        {
            // Örnek: _dbContext.Database.BeginTransaction();
            throw new NotImplementedException();
        }

        public void CloseTransaction()
        {
            // Örnek: Commit ya da Rollback işlemleri burada yapılır.
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepo<T> Repo<T>() where T : NewBaseEntity
        {
            throw new NotImplementedException();
        }
        #endregion
    }


}
