using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model;
using HerkesYazarOlsun.Model.Utils;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete
{
    public class EfNpSqlEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
    {
        private BaseNpSqlDbContext ctx;

        public BaseNpSqlDbContext _ctx
        {
            get
            {
                if (ctx == null)
                    ctx = new PostgreSqlContext();  
                return ctx;
            }
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

        public void Update(TEntity entity)
        {
            try
            {
                if (_ctx.Entry(entity).State == EntityState.Detached)
                    ctx = null;

                _ctx.Entry(entity).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveLog(ex, entity, "Update");
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _ctx.Set<TEntity>().AsNoTracking().ToList()
                : _ctx.Set<TEntity>().AsNoTracking().Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _ctx.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
        }

        public TEntity GetTrackingYok(Expression<Func<TEntity, bool>> filter)
        {
            return _ctx.Set<TEntity>().FirstOrDefault(filter);
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
            var connection = _ctx.Database.GetDbConnection();
            try
            {
                connection.Open();
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "GetSequenceNextVal";
                cmd.CommandType = CommandType.StoredProcedure;

                var param1 = new NpgsqlParameter("nameSeq", NpgsqlDbType.Varchar) { Value = sequneceName };
                var param2 = new NpgsqlParameter("nextValue", NpgsqlDbType.Bigint)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);

                cmd.ExecuteNonQuery();
                return Convert.ToInt64(param2.Value);
            }
            finally
            {
                connection.Close();
            }
        }

        private void SaveLog(Exception ex, TEntity entity, string action)
        {
            // logla
        }
    }

}
