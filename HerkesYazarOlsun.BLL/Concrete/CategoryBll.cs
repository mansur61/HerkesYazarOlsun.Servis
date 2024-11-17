using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class CategoryBll : ICategoryService
    {
        public Category GetCategory(long id)
        {
            Category cat = new Category();
            using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
            {
                cat = ctx.Category.Where(p => p.ID == id).FirstOrDefault();
            }
            return cat;
        }
        public Category GetCategoryById(long kitapId)
        {
            Category cat = new Category();
            using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
            {
                cat = ctx.Category.Where(p => p.BooksId == kitapId).FirstOrDefault();
            }
            return cat;
        }
    }
}
