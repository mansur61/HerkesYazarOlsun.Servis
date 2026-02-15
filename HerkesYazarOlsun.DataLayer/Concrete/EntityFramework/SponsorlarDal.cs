using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class SponsorlarDal : HybridEntityRepositoryBase<Sponsorlar>, ISponsorlarDal
    {
        public SponsorlarDal(
         EfSqlEntityRepositoryBase<Sponsorlar> sqlRepo,
         EfNpSqlEntityRepositoryBase<Sponsorlar> npgsqlRepo,
         IConfiguration config)
         : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
