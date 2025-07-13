using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class FavYazarDal : HybridRepo<FAVORI_YAZARLAR>, IFavYazarDal
    {
        public FavYazarDal(SqlRepo<FAVORI_YAZARLAR> sqlRepo, NpgsqlRepo<FAVORI_YAZARLAR> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
