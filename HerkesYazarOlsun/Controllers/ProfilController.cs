using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private IProfilDal prflDal;

        public ProfilController(IProfilDal prflDal)
        {
            this.prflDal = prflDal;
        }

        [HttpGet]
        [Route("GetProfilByLoginId")]
        public VM_PROFILE? GetProfilByLoginId(long loginId)
        {            
            var sonuc = prflDal.GetAllQueryable(p => p.LoginUserId == loginId).SingleOrDefault();
            var vmProfil = ObjectMapper.Map(sonuc, new VM_PROFILE());
            return vmProfil;
        }

    }
}