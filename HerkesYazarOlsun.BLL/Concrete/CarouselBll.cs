using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class CarouselBll : ICarouselService
    {

        ICarouselDuyuruDal _carouselDuyuruDal;
        public CarouselBll(ICarouselDuyuruDal carouselDuyuruDal)
        {
            _carouselDuyuruDal = carouselDuyuruDal;
        }

        public List<VM_CAROUSEL_DUYURU> GetDuyurular()
        {
            var spnsList = _carouselDuyuruDal.GetList(p => p.IS_DELETED == 0).ToList();
            var list = ObjectMapper.MapList(spnsList, new List<VM_CAROUSEL_DUYURU>());

            return list;
        }

    }
}
