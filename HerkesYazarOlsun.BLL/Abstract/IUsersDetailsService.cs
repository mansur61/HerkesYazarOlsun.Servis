
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IUsersDetailsService
    {  
        UsersDetails? Guncelle(UsersDetails usr, long tck);
        UsersDetails? Ekle(UsersDetails usr, string? mail);
        UsersDetails? Get(long LoginUserId);
        UsersDetails? GetUsersDetailsByLoginId(long loginId);
    }

}
