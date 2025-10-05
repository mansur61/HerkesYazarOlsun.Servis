using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IProfilService
    {
        VM_PROFILE? GetProfilByLoginId(long loginId);
         Profil? Get(long LoginUserId);
        Profil? Ekle(Profil ayar, string? mail);
        Profil? Guncelle(Profil ayar, long tck);
    }
}
