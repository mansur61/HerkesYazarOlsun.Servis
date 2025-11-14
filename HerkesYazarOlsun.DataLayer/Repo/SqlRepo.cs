using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore; 
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public class SqlRepo<T> : IRepo<T> , IIncludeRepo<T>  where T : NewBaseEntity
    {
        private readonly BaseSqlDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepo(BaseSqlDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public List<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }
        public List<T> GetAll() => _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0).ToList();

        public T Get(long id) => _dbSet.AsNoTracking().FirstOrDefault(x => x.ID == id && x.IS_DELETED == 0);

        public T Add(T entity, long tcNo)
        {
            entity.USER_CREATED_ID = tcNo;
            entity.CREATE_AT = DateTime.Now;
            entity.MODIFIED_AT = DateTime.Now;
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        // Diğer metodlar da benzer şekilde (Update, Delete, Guncelle, Sil)

        public long GetSequneceNextVal(string sequneceName)
        {
            throw new NotImplementedException("SQL Server için sequence desteği yok.");
        }
        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate)
                         .Where(x => x.IS_DELETED == 0); // Tracking açık
        }

        public IQueryable<T> GetAllQueryableNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking() // Tracking kapalı
                         .Where(predicate)
                         .Where(x => x.IS_DELETED == 0);
        }


        public IQueryable<T> GetAllQueryable()
        {
            return _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0); // Tracking açık
        }

        public T Ekle(T entity, string mail)
        {
            entity.OLUSTURAN_EMAIL = mail;
            entity.CREATE_AT = DateTime.Now;
            entity.MODIFIED_AT = DateTime.Now;
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity, long tcNo)
        {
            var existingEntity = _dbSet.Find(entity.ID);
            if (existingEntity == null || existingEntity.IS_DELETED == 1)
                throw new Exception("Entity not found or deleted.");

            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            existingEntity.USER_CREATED_ID = tcNo;
            existingEntity.MODIFIED_AT = DateTime.Now;

            _dbContext.SaveChanges();
            return existingEntity;
        }

        public T Guncelle(T entity, string mail)
        {
            var existingEntity = _dbSet.Find(entity.ID);
            if (existingEntity == null || existingEntity.IS_DELETED == 1)
                throw new Exception("Entity not found or deleted.");

            _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            existingEntity.USER_MODIFIED_MAIL = mail;
            existingEntity.MODIFIED_AT = DateTime.Now;

            _dbContext.SaveChanges();
            return existingEntity;
        }

        public void Sil(int id, string mail)
        {
            var entity = _dbSet.Find((long)id);
            if (entity == null || entity.IS_DELETED == 1)
                throw new Exception("Entity not found or already deleted.");

            entity.IS_DELETED = 1;
            entity.USER_MODIFIED_MAIL = mail;
            entity.MODIFIED_AT = DateTime.Now;
            //_dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity, long tcNo)
        {
            var existingEntity = _dbSet.Find(entity.ID);
            if (existingEntity == null || existingEntity.IS_DELETED == 1)
                throw new Exception("Entity not found or already deleted.");

            existingEntity.IS_DELETED = 1;
            existingEntity.USER_CREATED_ID = tcNo;
            existingEntity.MODIFIED_AT = DateTime.Now;

            _dbContext.SaveChanges();
        }
    }

}
