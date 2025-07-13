using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.Configuration;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class OdemeSponsorlariDal : HybridRepo<OdemeSponsorlari>, IOdemeSponsorlariDal
    {
        public OdemeSponsorlariDal(SqlRepo<OdemeSponsorlari> sqlRepo, NpgsqlRepo<OdemeSponsorlari> npgsqlRepo, IConfiguration config)
       : base(sqlRepo, npgsqlRepo, config)
        {
        }
    }
}
