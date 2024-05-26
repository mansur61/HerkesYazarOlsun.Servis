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

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public class Repo<T> : IRepo<T> where T : NewBaseEntity
    {
        private BaseNpSqlDbContext _dbContext;
        private DbSet<T> _dbSet;

        public Repo()
        {
            if (_dbContext == null)
            {
               
                _dbContext = new HerkesYazaOlsunContext();
            }

            _dbSet = _dbContext.Set<T>();

        }

        public Repo(HerkesYazaOlsunContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        #region Global Method

        private void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(T entity, long tcNo)
        {
            if (entity != null)
            {
                entity.USER_MODIFIED_ID = tcNo;
                entity.IS_DELETED = 1;
                entity.MODIFIED_AT = DateTime.Now;
                Update(entity, tcNo);
            }
        }

        public void Sil(int id, string mail)
        {
            var entity = Get(id);
            if (entity != null)
            {                
                entity.IS_DELETED = 1;
                entity.MODIFIED_AT = DateTime.Now;
                Guncelle(entity, mail);
            }
        }

        public void Sil(int id, long tcNo)
        {
            var entity = Get(id);
            Delete(entity, tcNo);
        }

        public T Update(T entity, long tcNo)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                HandleDetached(entity);
            }
            var _dbSet = _dbContext.Set<T>();
            entity.MODIFIED_AT = DateTime.Now;
            entity.USER_MODIFIED_ID = tcNo;
            entity.IS_MODIFIED = 1;
            //entity = _dbSet.Attach(entity);
            var updateEntity = _dbContext.Entry(entity);
            updateEntity.State = EntityState.Modified;
            _dbContext.SaveChanges();


            return entity;
        }
        public T Guncelle(T entity, string mail)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                HandleDetached(entity);
            }
            var _dbSet = _dbContext.Set<T>();
            entity.MODIFIED_AT = DateTime.Now;
            entity.USER_MODIFIED_MAIL = mail;
            entity.USER_MODIFIED_ID = 0;
            entity.IS_MODIFIED = 1;
            //entity = _dbSet.Attach(entity);
            var updateEntity = _dbContext.Entry(entity);
            updateEntity.State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }


        
        public T Add(T entity, long tcNo)
        {
            entity.USER_CREATED_ID = tcNo;
            entity.CREATE_AT = DateTime.Now;
            entity.MODIFIED_AT = DateTime.Now;
            var addEntity = _dbContext.Entry(entity);
            addEntity.State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public T Ekle(T entity, string mail)
        {
            entity.OLUSTURAN_EMAIL = mail;
            entity.CREATE_AT = DateTime.Now;
            entity.MODIFIED_AT = DateTime.Now;
            var addEntity = _dbContext.Entry(entity);
            addEntity.State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public T Get(long id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.IS_DELETED == 0 && x.ID == id);
        }

        public List<T> GetAll()
        {
            return _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0).ToList();
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> pregs = null)
        {
            if (pregs != null)
                return _dbSet.AsNoTracking().Where(pregs).Where(x => x.IS_DELETED == 0);
            else
                return _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0);
        }

        private bool HandleDetached(T entity)
        {
            //var objectContext = ((IObjectContextAdapter)_dbContext).ObjectContext;
            //var entitySet = objectContext.CreateObjectSet<T>();
            //var entityKey = objectContext.CreateEntityKey(entitySet.EntitySet.Name, entity);
            //object foundSet;
            //bool exists = objectContext.TryGetObjectByKey(entityKey, out foundSet);
            //if (exists)
            //{
            //    objectContext.Detach(foundSet);
            //}
            //return exists;
            _dbContext = new HerkesYazaOlsunContext();
            return true;
        }

        public long GetSequneceNextVal(string sequneceName)
        {
            using (HerkesYazaOlsunContext _ctx = new HerkesYazaOlsunContext())
            {
                NpgsqlConnection connection  = (NpgsqlConnection)_ctx.Database.GetDbConnection();
                try
                {
                    connection.Open();
                   NpgsqlCommand cmd = _ctx.Database.GetDbConnection().CreateCommand() as NpgsqlCommand;
                    cmd.CommandText = "GetSequenceNextVal";
                    cmd.CommandType = CommandType.StoredProcedure;

                    #region Parameters

                    NpgsqlParameter oNameOfParameter = new NpgsqlParameter("nameSeq", NpgsqlDbType.Varchar ,150,sequneceName);
                    NpgsqlParameter oNameOfParameter2 = new NpgsqlParameter("nextValue", NpgsqlDbType.Double, 0, sequneceName,
                        ParameterDirection.Output,false,50,50,DataRowVersion.Current, "nextValue");

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

      
        #endregion
    }
}
