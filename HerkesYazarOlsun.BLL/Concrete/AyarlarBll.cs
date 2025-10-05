using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class AyarlarBll : IAyarlarService
    {

        private IAyarlarDal ayrDal;
        public AyarlarBll(IAyarlarDal ayrDal)
        {
            this.ayrDal = ayrDal;
        }

        public Ayarlar? GetProfilByLoginId(long loginId)
        {
            var sonuc = ayrDal.GetAllQueryable(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

        public Ayarlar? Ekle(Ayarlar ayar,string? mail)
        {
            return ayrDal.Ekle(ayar, mail); ;
        }

        public Ayarlar? Guncelle(Ayarlar ayar, long tck)
        {
           return ayrDal.Update(ayar, tck);
        }
        public Ayarlar? GetAyar(long LoginUserId)
        {
            var sonuc = ayrDal.GetAllQueryable(p => p.LoginUserId == LoginUserId).FirstOrDefault();
            return sonuc;
        }
        
    }
}
