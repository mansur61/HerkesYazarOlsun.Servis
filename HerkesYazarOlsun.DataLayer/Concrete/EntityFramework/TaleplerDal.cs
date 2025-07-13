using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class TaleplerDal : HybridEntityRepositoryBase<TALEPLER>, ITaleplerDal
    {
        public TaleplerDal(
         EfSqlEntityRepositoryBase<TALEPLER> sqlRepo,
         EfNpSqlEntityRepositoryBase<TALEPLER> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
