using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class FavBookDal : HybridRepo<FavoriBooks>, IFavBookDal
    {
        public FavBookDal(SqlRepo<FavoriBooks> sqlRepo, NpgsqlRepo<FavoriBooks> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
