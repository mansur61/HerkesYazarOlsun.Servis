using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class BooksStarsDal : HybridEntityRepositoryBase<BooksStars>, IBooksStarsDal
    {
        public BooksStarsDal(
         EfSqlEntityRepositoryBase<BooksStars> sqlRepo,
         EfNpSqlEntityRepositoryBase<BooksStars> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }


}
