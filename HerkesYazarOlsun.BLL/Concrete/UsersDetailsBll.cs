using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class UsersDetailsBll : IUsersDetailsService
    {

        private IUsersDetailsDal usrDtlsDal;
        public UsersDetailsBll(IUsersDetailsDal usrDtlsDal)
        {
            this.usrDtlsDal = usrDtlsDal;
        }
         
        public UsersDetails? Ekle(UsersDetails ayar,string? mail)
        {
            return usrDtlsDal.Ekle(ayar, mail); ;
        }

        public UsersDetails? Guncelle(UsersDetails ayar, long tck)
        {
           return usrDtlsDal.Update(ayar, tck);
        }
        public UsersDetails? Get(long LoginUserId)
        { 
            var sonuc = usrDtlsDal.GetAllQueryable(p => p.LoginUserId == LoginUserId).FirstOrDefault();
            return sonuc;
        }

        public UsersDetails? GetUsersDetailsByLoginId(long loginId)
        {
            var sonuc = usrDtlsDal.GetAllQueryableNoTracking(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

    }
}
