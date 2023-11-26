

using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("GetKisiByTC")]
        public Users? GetKisiByTC(long id)
        {
            IUsersBll kisilerBll = InstanceFactory.GetInstance<IUsersBll>();
            var getKisiler = kisilerBll.GetKullanicilar();
            var getKisi = getKisiler.Where(p => p.ID == id).FirstOrDefault();
            return getKisi;
        }

        [HttpPost]
        [Route("GetKisiler")]
        public List<Users> GetKisiler(VM_ARAMA_INPUT arama)
        {
            IUsersBll kisilerBll = InstanceFactory.GetInstance<IUsersBll>();
            List<Users> users = new List<Users>();
            var getKisiler = kisilerBll.GetKullanicilar();
            if (!string.IsNullOrEmpty(arama.YAZAR_ADI))
            {
                getKisiler = getKisiler.Where(p => p.NAME.Contains(arama.YAZAR_ADI!)).ToList();
            }
           
            return getKisiler;
        }

        [HttpPost]
        [Route("PostFavoriSaveWriter")]
        public FAVORI_YAZARLAR PostFavoriSaveWriter(VM_FAVORI_YAZARLAR fav)
        {
            IFavYazarDal yazarDal = InstanceFactory.GetInstance<IFavYazarDal>();
            var favYazar = ObjectMapper.Map(fav, new FAVORI_YAZARLAR());
            favYazar = yazarDal.Add(favYazar, fav.tck);
            return favYazar;
        }


    }
}