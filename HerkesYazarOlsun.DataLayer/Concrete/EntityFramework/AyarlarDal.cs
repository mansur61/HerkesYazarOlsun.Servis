using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class AyarlarDal : HybridRepo<Ayarlar>, IAyarlarDal
    {
        public AyarlarDal(SqlRepo<Ayarlar> sqlRepo, NpgsqlRepo<Ayarlar> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
