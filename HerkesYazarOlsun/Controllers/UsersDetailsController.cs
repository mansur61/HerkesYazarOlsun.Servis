using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDetailsController : ControllerBase
    {
        private IUsersDetailsService usrDtlsSrv;

        public UsersDetailsController(IUsersDetailsService usrDtlsSrv)
        {
            this.usrDtlsSrv = usrDtlsSrv;
        }

        [HttpGet]
        [Route("GetUsersDetailsByLoginId")]
        public UsersDetails? GetUsersDetailsByLoginId(long loginId)
        {
            var sonuc = usrDtlsSrv.GetUsersDetailsByLoginId(loginId);
            return sonuc;
        }

    }
}