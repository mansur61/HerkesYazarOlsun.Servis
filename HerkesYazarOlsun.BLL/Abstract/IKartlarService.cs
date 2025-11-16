using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IKartlarService
    {
        Kartlar Ekle(Kartlar kart, string? mail);
    }
}
