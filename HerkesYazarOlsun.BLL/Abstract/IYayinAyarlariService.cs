using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IYayinAyarlariService
    {
        List<YayinAyarlari>? GetYayinAyarlari();
        YayinAyarlari? GetYayinAyarlariByBookId(long id);
    }
}
