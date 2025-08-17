using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class WriterStarsDal : HybridEntityRepositoryBase<WriterStars>, IWriterStarsDal
    {
        public WriterStarsDal(
         EfSqlEntityRepositoryBase<WriterStars> sqlRepo,
         EfNpSqlEntityRepositoryBase<WriterStars> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
