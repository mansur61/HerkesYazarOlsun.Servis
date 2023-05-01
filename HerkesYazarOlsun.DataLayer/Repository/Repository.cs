using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(HerkesYazaOlsunContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        #region Global Method
        public long GetSequneceNextVal(string sequneceName)
        {
            using (HerkesYazaOlsunContext _ctx = new HerkesYazaOlsunContext())
            {
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
        }
        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).SingleOrDefault();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        #endregion
    }
}
