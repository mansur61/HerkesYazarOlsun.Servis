using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class YayinAyarlariBll : IYayinAyarlariService
    {

        private IYayinAyarlariDal yayrDal;
        public YayinAyarlariBll(IYayinAyarlariDal yayrDal)
        {
            this.yayrDal = yayrDal;
        }

        public List<YayinAyarlari>? GetYayinAyarlari()
        {
            var sonuc = yayrDal.GetList().ToList();
            return sonuc;
        }

        public YayinAyarlari? GetYayinAyarlariByBookId(long id)
        {
            var sonuc = yayrDal.Get(p => p.BookId == id);
            return sonuc;
        }

    }
}
