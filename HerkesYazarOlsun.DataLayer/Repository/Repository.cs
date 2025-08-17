using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("DbContext cannot be null.");
            _dbSet = _dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll() => _dbSet.AsNoTracking();
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate) => _dbSet.AsNoTracking().Where(predicate);
        public virtual T GetById(int id) => _dbSet.Find(id);
        public virtual T Get(Expression<Func<T, bool>> predicate) => _dbSet.AsNoTracking().SingleOrDefault(predicate);
        public virtual void Add(T entity) => _dbSet.Add(entity);
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null) Delete(entity);
        }

        public abstract long GetSequneceNextVal(string sequneceName);
    }


}
