using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselDuyuruController : BaseApiController
    {
        ICarouselDuyuruDal _carouselDuyuruDal;
        public CarouselDuyuruController ( ICarouselDuyuruDal carouselDuyuruDal ,IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
            : base(userAccessor, unitOfWork, configuration)
        {
            _carouselDuyuruDal = carouselDuyuruDal;
        }

        [HttpGet]
        [Route("GetDuyurular")]
        public List<VM_CAROUSEL_DUYURU> GetDuyurular()
        {
            var spnsList = _carouselDuyuruDal.GetList(p=>p.IS_DELETED == 0).ToList();
            var list = ObjectMapper.MapList(spnsList, new List<VM_CAROUSEL_DUYURU>());

            return list;
        }

    }
}
