
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IUsersService
    {
        List<Users> GetKullanicilar();
        VM_Stars GetMaxStarWriterById(long id);
    }
}
