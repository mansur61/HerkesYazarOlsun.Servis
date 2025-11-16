
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBildirimlerService
    {
        Bildirimler? Guncelle(Bildirimler usr, long tck);
        Bildirimler? Ekle(Bildirimler usr, string? mail);
        Bildirimler? Get(long LoginUserId);
    }

}
