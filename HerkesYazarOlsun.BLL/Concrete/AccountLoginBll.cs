using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class AccountLoginBll : IAccountLoginService
    {

        IAccountLoginDal accLoginDal;
        public AccountLoginBll(IAccountLoginDal accLoginDal)
        {
            this.accLoginDal = accLoginDal;
        }
         
        public AccountLogin? Ekle(AccountLogin ayar,string? mail)
        {
            return accLoginDal.Ekle(ayar, mail); ;
        }

        public AccountLogin? Guncelle(AccountLogin ayar, long tck)
        {
           return accLoginDal.Update(ayar, tck);
        }
        public AccountLogin? Get(long LoginUserId)
        { 
            var sonuc = accLoginDal.GetAllQueryable(p => p.LoginUserId == LoginUserId).FirstOrDefault();
            return sonuc;
        }
        
    }
}
