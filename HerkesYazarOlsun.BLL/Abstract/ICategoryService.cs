using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface ICategoryService
    {
         Category GetCategory(long id);
        List<Category> GetCategories();
    }
}
