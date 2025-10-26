using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface ICategoryYayinAyarlariService
    {
        List<CategoryYayinAyarlari>? GetCategoryYayinAyarlari();
        CategoryYayinAyarlari? GetYayinAyarlariByCategoryId(long id);
    }
}
