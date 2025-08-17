using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class WriterFollowDal : HybridEntityRepositoryBase<WriterFollow>, IWriterFollowDal
    {
        public WriterFollowDal(
         EfSqlEntityRepositoryBase<WriterFollow> sqlRepo,
         EfNpSqlEntityRepositoryBase<WriterFollow> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
