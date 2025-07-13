using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;


namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class BooksPagesDal : HybridRepo<BooksPages>, IBooksPagesDal
    {
        public BooksPagesDal(SqlRepo<BooksPages> sqlRepo, NpgsqlRepo<BooksPages> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
