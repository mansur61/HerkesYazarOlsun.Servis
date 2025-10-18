
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorlarController : BaseApiController
    {

        private ISponsorlarService _spnSrv;
        public SponsorlarController(ISponsorlarService _spnSrv, IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
            : base(userAccessor, unitOfWork, configuration)
        {
           this._spnSrv = _spnSrv;
        }
         
         
        [HttpPost]
        [Route("PostSponsorlar")]
        public ServiceResult PostSponsorlar(VM_SPONSORLAR spns)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var spnsEntity = ObjectMapper.Map(spns, new Sponsorlar());

            try
            {

                spnsEntity = _spnSrv.Add(spnsEntity);

                result.State = MessageResultState.SUCCESS;
                return result;
            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }

            result.Result = spnsEntity;
            return result;
        }

        [HttpGet]
        [Route("GetSponsorlar")]
        public List<VM_SPONSORLAR> GetSponsorlar()
        {
            var spnsList = _spnSrv.GetSponsorlar();

            return spnsList;
        }

        [HttpGet]
        [Route("GetSponsorlarById")]
        public VM_SPONSORLAR GetSponsorlarById(long id)
        {
            var spns = _spnSrv.GetSponsorlarById(id);

            return spns;
        }

    }
}