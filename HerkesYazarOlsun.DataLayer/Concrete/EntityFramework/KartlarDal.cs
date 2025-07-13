using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class KartlarDal : HybridRepo<Kartlar>, IKartlarDal
    {
        public KartlarDal(SqlRepo<Kartlar> sqlRepo, NpgsqlRepo<Kartlar> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
