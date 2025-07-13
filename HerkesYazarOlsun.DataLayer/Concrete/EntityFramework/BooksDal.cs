using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class BooksDal : HybridRepo<Books>, IBooksDal
    {
        public BooksDal(SqlRepo<Books> sqlRepo, NpgsqlRepo<Books> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
