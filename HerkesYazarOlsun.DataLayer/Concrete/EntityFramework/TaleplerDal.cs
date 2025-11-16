using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class TaleplerDal : HybridEntityRepositoryBase<Talepler>, ITaleplerDal
    {
        public TaleplerDal(
         EfSqlEntityRepositoryBase<Talepler> sqlRepo,
         EfNpSqlEntityRepositoryBase<Talepler> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
