using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class CategoryBll : ICategoryService
    {
        private ICategoryDal categoryDal;   
        public CategoryBll(ICategoryDal _categoryDal)
        {
            categoryDal = _categoryDal;
        }

        public List<Category> GetCategories()
        {             
            return categoryDal.GetList().ToList();             
        }

        public Category GetCategory(long id)
        {          
            return categoryDal.Get(p => p.ID == id);            
        }

    }
}
