using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselDuyuruController : BaseApiController
    {
       private ICarouselService _carouselDuyuruSrv;
        public CarouselDuyuruController (ICarouselService carouselDuyurusrv, IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
            : base(userAccessor, unitOfWork, configuration)
        {
            _carouselDuyuruSrv = carouselDuyurusrv;
        }

        [HttpGet]
        [Route("GetDuyurular")]
        public List<VM_CAROUSEL_DUYURU> GetDuyurular()
        {
            var list = _carouselDuyuruSrv.GetDuyurular();

            return list;
        }

    }
}
