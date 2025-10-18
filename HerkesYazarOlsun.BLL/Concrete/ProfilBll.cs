using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class ProfilBll : IProfilService
    {

        private IProfilDal _prflDal;
        public ProfilBll(IProfilDal prflDal)
        {
            _prflDal = prflDal;
        }

        public VM_PROFILE? GetProfilByLoginId(long loginId)
        {
            var sonuc = _prflDal.GetAllQueryable(p => p.UserId == loginId).SingleOrDefault();
            var vmProfil = ObjectMapper.Map(sonuc, new VM_PROFILE());
            return vmProfil;
        }

        public Profil? Ekle(Profil ayar, string? mail)
        {
            return _prflDal.Ekle(ayar, mail); ;
        }

        public Profil? Guncelle(Profil ayar, long tck)
        {
            return _prflDal.Update(ayar, tck);
        }
        public Profil? Get(long LoginUserId)
        {
            var sonuc = _prflDal.GetAllQueryable(p => p.UserId == LoginUserId).FirstOrDefault();
            return sonuc;
        }

    }
}
