using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class FavorilerDal : HybridRepo<Favoriler>, IFavorilerDal
    {
        public FavorilerDal(SqlRepo<Favoriler> sqlRepo, NpgsqlRepo<Favoriler> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
