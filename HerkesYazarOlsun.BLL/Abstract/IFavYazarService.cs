
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IFavoriYazarlarService
    {
        FavoriYazarlar? Guncelle(FavoriYazarlar ayar, long tck);
        FavoriYazarlar? Ekle(FavoriYazarlar ayar, string mail);
        FavoriYazarlar? Get(long LoginUserId);
    }

}
