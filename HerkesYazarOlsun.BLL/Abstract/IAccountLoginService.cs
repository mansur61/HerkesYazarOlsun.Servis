
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IAccountLoginService
    {
        AccountLogin? Guncelle(AccountLogin usr, long tck);
        AccountLogin? Ekle(AccountLogin usr, string? mail);
        AccountLogin? Get(long LoginUserId);
    }

}
