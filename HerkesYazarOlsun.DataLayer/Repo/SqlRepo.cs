using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public class SqlRepo<T> : IRepo<T> where T : NewBaseEntity
    {
        private readonly BaseSqlDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepo(BaseSqlDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
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
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public T Ekle(T entity, string mail)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity, long tcNo)
        {
            throw new NotImplementedException();
        }

        public T Guncelle(T entity, string mail)
        {
            throw new NotImplementedException();
        }

        public void Sil(int id, string mail)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity, long tcNo)
        {
            throw new NotImplementedException();
        }
    }

}
