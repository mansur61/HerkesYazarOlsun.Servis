using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{ 
    public class YayinAyarlariDal : HybridEntityRepositoryBase<YayinAyarlari>, IYayinAyarlariDal
    {
        public YayinAyarlariDal(
         EfSqlEntityRepositoryBase<YayinAyarlari> sqlRepo,
         EfNpSqlEntityRepositoryBase<YayinAyarlari> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
