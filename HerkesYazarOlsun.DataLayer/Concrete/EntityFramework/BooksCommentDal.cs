using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class BooksCommentDal : HybridRepo<BooksComment>, IBooksCommentDal
    {
        public BooksCommentDal(SqlRepo<BooksComment> sqlRepo, NpgsqlRepo<BooksComment> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
