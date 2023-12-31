using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Repo;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class KartlarDal : Repo<Kartlar>, IKartlarDal
    {
    }
}
