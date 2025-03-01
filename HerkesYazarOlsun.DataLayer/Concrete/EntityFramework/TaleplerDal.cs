using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.DataLayer.Concrete.EntityFramework
{
    public class TaleplerDal : EfEntityRepositoryBase<TALEPLER, HerkesYazaOlsunContext>, ITaleplerDal
    {
    }
}
