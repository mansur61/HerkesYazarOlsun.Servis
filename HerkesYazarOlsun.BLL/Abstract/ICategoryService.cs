using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface ICategoryService
    {
         Category GetCategory(long id);
        Category GetCategoryById(long kitapId);
    }
}
