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

        public YayinAyarlari? GetYayinAyarlari()
        {
            var sonuc = yayrDal.GetList().SingleOrDefault();
            return sonuc;
        }

    }
}
