using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class CategoryYayinAyarlariBll : ICategoryYayinAyarlariService
    {

        private ICategoryYayinAyarlariDal yayrDal;
        public CategoryYayinAyarlariBll(ICategoryYayinAyarlariDal yayrDal)
        {
            this.yayrDal = yayrDal;
        }

        public List<CategoryYayinAyarlari>? GetCategoryYayinAyarlari()
        {
            var sonuc = yayrDal.GetList().ToList();
            return sonuc;
        }

        public CategoryYayinAyarlari? GetYayinAyarlariByCategoryId(long id)
        {
            var sonuc = yayrDal.Get(p => p.CategoryId == id);
            return sonuc;
        }

    }
}
