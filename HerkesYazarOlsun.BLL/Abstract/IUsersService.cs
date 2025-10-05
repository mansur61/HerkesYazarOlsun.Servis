
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IUsersService
    {
        List<Users> GetKullanicilar();
        VM_Stars GetMaxStarWriterById(long id);
        Users? Guncelle(Users usr, long tck);
        Users? Ekle(Users usr, string? mail);
        Users? Get(long LoginUserId);
        Users? GetMail(string mail);
        Users? GetUserrName(string username);
    }

}
