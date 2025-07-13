using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;
namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class ProfilDal : HybridRepo<Profil>, IProfilDal
    {
        public ProfilDal(SqlRepo<Profil> sqlRepo, NpgsqlRepo<Profil> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
