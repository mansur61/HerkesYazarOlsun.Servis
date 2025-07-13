using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public class HybridRepo<T> : IRepo<T> where T : NewBaseEntity
    {
        private readonly IRepo<T> _repo;

        public HybridRepo(SqlRepo<T> sqlRepo, NpgsqlRepo<T> npgsqlRepo, IConfiguration config)
        {
            var dbType = config["DbType"];
            _repo = _repo = dbType == "Sql" ? sqlRepo : npgsqlRepo;
        }

        public List<T> GetAll() => _repo.GetAll();
        public T Get(long id) => _repo.Get(id);
        public T Add(T entity, long tcNo) => _repo.Add(entity, tcNo);
        public long GetSequneceNextVal(string sequneceName) => _repo.GetSequneceNextVal(sequneceName);

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
        // diğer metodlar da bu şekilde _repo'ya delege edilir
    }

}
