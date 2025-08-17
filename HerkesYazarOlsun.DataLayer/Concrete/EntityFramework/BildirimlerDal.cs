using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class BildirimlerDal : HybridRepo<Bildirimler>, IBildirimlerDal
    {
        public BildirimlerDal(SqlRepo<Bildirimler> sqlRepo, NpgsqlRepo<Bildirimler> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
