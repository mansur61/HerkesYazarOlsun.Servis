using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDetailsController : ControllerBase
    {
        private IUsersDetailsDal usrDtlsDal;

        public UsersDetailsController(IUsersDetailsDal usrDtlsDal)
        {
            this.usrDtlsDal = usrDtlsDal;
        }

        [HttpGet]
        [Route("GetUsersDetailsByLoginId")]
        public UsersDetails? GetUsersDetailsByLoginId(long loginId)
        {            
            var sonuc = usrDtlsDal.GetAllQueryable(p => p.LoginUserId == loginId).SingleOrDefault();
            return sonuc;
        }

    }
}