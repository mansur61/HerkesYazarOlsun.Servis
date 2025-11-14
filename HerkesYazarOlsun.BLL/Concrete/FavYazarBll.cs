using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class FavYazarBll : IFavoriYazarlarService
    {

        IFavYazarDal yazarDal;
        public FavYazarBll(IFavYazarDal yazarDal)
        {
            this.yazarDal = yazarDal;
        }
         
        public FavoriYazarlar? Ekle(FavoriYazarlar ayar,string mail)
        {
            return yazarDal.Ekle(ayar, mail);  
        }

        public FavoriYazarlar? Guncelle(FavoriYazarlar ayar, long tck)
        {
           return yazarDal.Update(ayar, tck);
        }
        public FavoriYazarlar? Get(long LoginUserId)
        {
            var sonuc = yazarDal.Get( LoginUserId);
            return sonuc;
        }

        public List<FavoriYazarlar> GetFavoriYazarlarByuserId(long userId)
        {
            return yazarDal.GetAllQueryableNoTracking(p => p.LoginUserId == userId).ToList();
        }

    }
}
