using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Repo
{
    public class HybridRepo<T> : IRepo<T> , IIncludeRepo<T> where T : NewBaseEntity
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
            return _repo.GetAllQueryable(predicate);
        }

        public IQueryable<T> GetAllQueryable()
        {
           return _repo.GetAllQueryable();
        }

        public T Ekle(T entity, string mail)
        {
            return _repo.Ekle(entity, mail);
        }

        public T Update(T entity, long tcNo)
        {
            return _repo.Update(entity, tcNo);
        }
 

        public IQueryable<T> GetAllQueryableNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _repo.GetAllQueryableNoTracking(predicate);
        }

        public T Guncelle(T entity, string mail)
        {
            return _repo.Guncelle(entity, mail);
        }

        public void Sil(int id, string mail)
        {
            _repo.Sil(id, mail);
        }

        public void Delete(T entity, long tcNo)
        {
           _repo.Delete(entity, tcNo);
        }

        public List<T> GetAllWithIncludes(params Expression<Func<T, object>>[] includes)
        {
            // _repo aslında SqlRepo<T> ise Include çalışır
            if (_repo is IIncludeRepo<T> includeRepo)
            {
                return includeRepo.GetAllWithIncludes(includes);
            }

            throw new NotSupportedException("Include sadece SqlRepo üzerinde desteklenir.");
        }
    }

}
