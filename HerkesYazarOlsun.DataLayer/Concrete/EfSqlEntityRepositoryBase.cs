using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; 
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model; 

namespace HerkesYazarOlsun.DataLayer.Concrete
{
    public class EfSqlEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    { 
        private  SqlServerContext _ctx;

        // DbContext DI ile inject edilir
        public EfSqlEntityRepositoryBase(SqlServerContext context)
        {
            _ctx = context;
        }
         
        public TEntity Add(TEntity entity)
        {
            try
            {
                _ctx.Entry(entity).State = EntityState.Added;
                _ctx.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                SaveLog(ex, entity, "Add");
                return null;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _ctx.Entry(entity).State = EntityState.Deleted;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveLog(ex, entity, "Delete");
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _ctx.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _ctx.Set<TEntity>().AsNoTracking().ToList()
                : _ctx.Set<TEntity>().AsNoTracking().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (_ctx.Entry(entity).State == EntityState.Detached)
                {
                    HandleDetached(entity);
                }

                _ctx.Entry(entity).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveLog(ex, entity, "Update");
            }
        }

        public GenericResult<TEntity> PagedList(Expression<Func<TEntity, bool>> filter = null, int pNumber = 0, int pSize = 10)
        {
            var query = _ctx.Set<TEntity>().AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            var data = query.Skip(pNumber).Take(pSize).ToList();
            var count = query.Count();

            return new GenericResult<TEntity>
            {
                data = data,
                recordsFiltered = count,
                recordsTotal = count
            };
        }

        public long GetSequneceNextVal(string sequneceName)
        {
            try
            {
                var sql = $"SELECT NEXT VALUE FOR {sequneceName}";
                var nextVal = _ctx.Database.ExecuteSqlRaw($"SELECT NEXT VALUE FOR {sequneceName}");

                // Ancak ExecuteSqlRaw sadece etki yapan işlemler için kullanılır.
                // Gerçek değeri döndürmek için FromSqlRaw kullanılır.

                var result = _ctx.Set<SequenceResult>()
                                 .FromSqlRaw($"SELECT NEXT VALUE FOR {sequneceName} AS Value")
                                 .AsEnumerable()
                                 .FirstOrDefault();

                return result?.Value ?? 0;
            }
            catch (Exception ex)
            {
                SaveLog(ex, new TEntity(), "GetSequneceNextVal");
                return 0;
            }
        }
          

        private bool HandleDetached(TEntity entity)
        {
            _ctx = null;
            return true;
        }

        private void SaveLog(Exception ex, TEntity entity, string action)
        {
            // loglama yapılabilir
        }
    }

    public class SequenceResult
    {
        public long Value { get; set; }
    }
}


