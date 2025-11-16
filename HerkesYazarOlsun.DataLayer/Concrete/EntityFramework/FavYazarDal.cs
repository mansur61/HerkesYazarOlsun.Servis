using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class FavYazarDal : HybridRepo<FavoriYazarlar>, IFavYazarDal
    {
        public FavYazarDal(SqlRepo<FavoriYazarlar> sqlRepo, NpgsqlRepo<FavoriYazarlar> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
