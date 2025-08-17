using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class FavorilerDal : HybridRepo<FAVORILER>, IFavorilerDal
    {
        public FavorilerDal(SqlRepo<FAVORILER> sqlRepo, NpgsqlRepo<FAVORILER> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
