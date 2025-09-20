using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class CategoryBll : ICategoryService
    {
        public List<Category> GetCategories()
        {
            List<Category> cats = new List<Category>();
            using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
            {
                cats = ctx.Category.ToList();
            }
            return cats;
        }

        public Category GetCategory(long id)
        {
            Category cat = new Category();
            using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
            {
                cat = ctx.Category.Where(p => p.ID == id).FirstOrDefault();
            }
            return cat;
        }

    }
}
