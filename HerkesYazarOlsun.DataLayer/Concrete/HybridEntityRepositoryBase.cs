using HerkesYazarOlsun.Model;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete
{
    public class HybridEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _repo;

        public HybridEntityRepositoryBase(
            EfSqlEntityRepositoryBase<TEntity> sqlRepo,
            EfNpSqlEntityRepositoryBase<TEntity> npgsqlRepo,
            IConfiguration config)
        {
            var dbType = config["DbType"];
            _repo = dbType == "Sql" ? sqlRepo : npgsqlRepo;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
            => _repo.Get(filter);

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
            => _repo.GetList(filter);

        public TEntity Add(TEntity entity)
            => _repo.Add(entity);

        public void Update(TEntity entity)
            => _repo.Update(entity);

        public void Delete(TEntity entity)
            => _repo.Delete(entity);

        public long GetSequneceNextVal(string sequence)
            => _repo.GetSequneceNextVal(sequence);
    }

}
