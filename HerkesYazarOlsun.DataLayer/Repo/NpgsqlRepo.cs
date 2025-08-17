using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public class NpgsqlRepo<T> : IRepo<T> where T : NewBaseEntity
    {
        private readonly BaseNpSqlDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public NpgsqlRepo(BaseNpSqlDbContext dbContext)
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

        public long GetSequneceNextVal(string sequneceName)
        {
            var connection = _dbContext.Database.GetDbConnection();
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
            connection.Close();

            return Convert.ToInt64(param2.Value);
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0).Where(predicate);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _dbSet.AsNoTracking().Where(x => x.IS_DELETED == 0);
        }

        public T Ekle(T entity, string mail)
        {
            entity.USER_MODIFIED_MAIL = mail;
            entity.CREATE_AT = DateTime.Now;
            entity.MODIFIED_AT = DateTime.Now;
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity, long tcNo)
        {
            entity.USER_MODIFIED_ID = tcNo;
            entity.MODIFIED_AT = DateTime.Now;
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Guncelle(T entity, string mail)
        {
            entity.USER_MODIFIED_MAIL = mail;
            entity.MODIFIED_AT = DateTime.Now;
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Sil(int id, string mail)
        {
            var entity = _dbSet.FirstOrDefault(x => x.ID == id && x.IS_DELETED == 0);
            if (entity != null)
            {
                entity.IS_DELETED = 1;
                entity.USER_MODIFIED_MAIL = mail;
                entity.MODIFIED_AT = DateTime.Now;
                _dbSet.Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(T entity, long tcNo)
        {
            entity.IS_DELETED = 1;
            entity.USER_MODIFIED_ID = tcNo;
            entity.MODIFIED_AT = DateTime.Now;
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

    }

}
