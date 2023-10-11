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
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
   where TEntity : class, IEntity, new()
   where TContext : BaseNpSqlDbContext, new()
    {
        private TContext ctx;
        public TContext _ctx
        {
            get
            {
                if (ctx == null)
                {
                    ctx = new TContext();
                }
                return ctx;
            }
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                var addedEntity = _ctx.Entry(entity);
                addedEntity.State = EntityState.Added;
                _ctx.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                SaveLog(ex, entity, "Add");
                return null;
            }
        }

        private void SaveLog(Exception ex, TEntity entity, string v)
        {
            
        }

        public void Delete(TEntity entity)
        {
            try
            {
                var deletedEntity = _ctx.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
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

        public long GetSequneceNextVal(string sequneceName)
        {
            //var param1 = new OracleParameter { ParameterName = "sequneceName", OracleDbType = OracleDbType.Varchar2, Direction = ParameterDirection.Input, Value = sequneceName };

            //var param2 = new OracleParameter { ParameterName = "nextValue", OracleDbType = OracleDbType.Int32, Direction = ParameterDirection.Output, Size = 255 };

            //string sql = $"BEGIN GetSequenceNextVal(:sequneceName, :nextValue); end;";

            //var val = _ctx.SqlQueryDapper<object>(sql, new object[] { param1, param2 }).ToList();
            //var nextVal = ((dynamic)param2.Value).Value;

            //int result = Convert.ToInt32(nextVal);

            //return result;
            NpgsqlConnection connection = (NpgsqlConnection)_ctx.Database.GetDbConnection();
            try
            {
                connection.Open();
                NpgsqlCommand cmd = _ctx.Database.GetDbConnection().CreateCommand() as NpgsqlCommand;
                cmd.CommandText = "GetSequenceNextVal";
                cmd.CommandType = CommandType.StoredProcedure;

                

                #region Parameters

                NpgsqlParameter oNameOfParameter = new NpgsqlParameter("nameSeq", NpgsqlDbType.Varchar, 150, sequneceName);
                NpgsqlParameter oNameOfParameter2 = new NpgsqlParameter("nextValue", NpgsqlDbType.Double, 0, sequneceName,
                    ParameterDirection.Output, false, 50, 50, DataRowVersion.Current, "nextValue");

                cmd.Parameters.Add(oNameOfParameter);
                cmd.Parameters.Add(oNameOfParameter2);

                #endregion Parameters

                var i = cmd.ExecuteNonQuery();
                var val = Convert.ToInt64(oNameOfParameter2.Value.ToString());
                return val;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void Update(TEntity entity)
        {
            //var _dbSet = _ctx.Set<TEntity>();
            //entity = _dbSet.Attach(entity);
            //_ctx.Entry(entity).State = EntityState.Modified;
            //var updatedEntity = _ctx.Entry(entity);
            //updatedEntity.State = EntityState.Modified;
            //_ctx.SaveChanges();

            try
            {
                if (_ctx.Entry(entity).State == EntityState.Detached)
                {
                    HandleDetached(entity);
                }
                var _dbSet = _ctx.Set<TEntity>();
                var updateEntity = _ctx.Entry(entity);
                updateEntity.State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                SaveLog(ex, entity, "Update");
            }
        }

        private bool HandleDetached(TEntity entity)
        {
            //var objectContext = ((IDbContextDependencies)_ctx).ObjectContext;
            //var entitySet = objectContext.CreateObjectSet<TEntity>();
            //var entityKey = objectContext.CreateEntityKey(entitySet.EntitySet.Name, entity);
            //object foundSet;
            //bool exists = objectContext.TryGetObjectByKey(entityKey, out foundSet);
            //if (exists)
            //{
            //    objectContext.Detach(foundSet);
            //}
            //return exists;
            ctx = null;
            return true;
        }

        public GenericResult<TEntity> PagedList(Expression<Func<TEntity, bool>> filter = null, int pNumber = 0, int pSize = 10)
        {
            var data = filter == null
           ? _ctx.Set<TEntity>().AsNoTracking().ToList()
           : _ctx.Set<TEntity>().AsNoTracking().Where(filter).Skip(pNumber).Take(pSize).ToList();

            var count = filter == null
           ? _ctx.Set<TEntity>().AsNoTracking().Count()
           : _ctx.Set<TEntity>().AsNoTracking().Where(filter).Skip(pNumber).Take(pSize).Count();
            var result = new GenericResult<TEntity>()
            {
                data = data,
                recordsTotal = count,
                recordsFiltered = count,
            };

            return result;
        }
    }
}