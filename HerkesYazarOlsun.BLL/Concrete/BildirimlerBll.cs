using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BildirimlerBll : IBildirimlerService
    {

        private IBildirimlerDal usrDtlsDal;
        public BildirimlerBll(IBildirimlerDal usrDtlsDal)
        {
            this.usrDtlsDal = usrDtlsDal;
        }
         
        public Bildirimler? Ekle(Bildirimler ayar,string? mail)
        {
            return usrDtlsDal.Ekle(ayar, mail); ;
        }

        public Bildirimler? Guncelle(Bildirimler ayar, long tck)
        {
           return usrDtlsDal.Update(ayar, tck);
        }
        public Bildirimler? Get(long LoginUserId)
        { 
            var sonuc = usrDtlsDal.GetAllQueryable(p => p.LoginUserId == LoginUserId).FirstOrDefault();
            return sonuc;
        }
        
    }
}
