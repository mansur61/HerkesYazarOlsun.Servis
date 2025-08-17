using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repository
{
    public class HybridRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repo;

        public HybridRepository(
            RepositorySql<T> sqlRepo,
            RepositoryNpgsql<T> npgsqlRepo,
            IConfiguration config)
        {
            var dbType = config["DbType"];  
            _repo = dbType == "Sql" ? sqlRepo : npgsqlRepo;
        }

        public IQueryable<T> GetAll() => _repo.GetAll();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate) => _repo.GetAll(predicate);
        public T GetById(int id) => _repo.GetById(id);
        public T Get(Expression<Func<T, bool>> predicate) => _repo.Get(predicate);
        public void Add(T entity) => _repo.Add(entity);
        public void Update(T entity) => _repo.Update(entity);
        public void Delete(T entity) => _repo.Delete(entity);
        public void Delete(int id) => _repo.Delete(id);
        public long GetSequneceNextVal(string sequneceName) => _repo.GetSequneceNextVal(sequneceName);
    }

}
