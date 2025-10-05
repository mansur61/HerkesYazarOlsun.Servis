using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private IProfilService prflSrv;

        public ProfilController(IProfilService prflSrv)
        {
            this.prflSrv = prflSrv;
        }

        [HttpGet]
        [Route("GetProfilByLoginId")]
        public VM_PROFILE? GetProfilByLoginId(long loginId)
        {
            var sonuc = prflSrv.GetProfilByLoginId(loginId);
            return sonuc;
        }

    }
}