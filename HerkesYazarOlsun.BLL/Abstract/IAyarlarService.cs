using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IAyarlarService
    {
        Ayarlar? GetProfilByLoginId(long loginId);
        Ayarlar? Ekle(Ayarlar ayar, string? mail);
        Ayarlar? Guncelle(Ayarlar ayar, long tck);
        Ayarlar? GetAyar(long LoginUserId);

    }
}
