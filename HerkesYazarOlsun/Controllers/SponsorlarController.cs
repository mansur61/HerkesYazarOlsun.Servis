
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract; 
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using HerkesYazarOlsun.Servis.Controllers;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorlarController : BaseApiController
    {

        private ISponsorlarDal _spnsDal;
        public SponsorlarController(  ISponsorlarDal spnsDal, IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
            : base(userAccessor, unitOfWork, configuration)
        {
            _spnsDal = spnsDal;
        }
         
         
        [HttpPost]
        [Route("PostSponsorlar")]
        public ServiceResult PostSponsorlar(VM_SPONSORLAR spns)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var spnsEntity = ObjectMapper.Map(spns, new Sponsorlar());

            try
            {

                spnsEntity = _spnsDal.Add(spnsEntity);

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
            var spnsList = _spnsDal.GetList().ToList();
            var list = ObjectMapper.MapList(spnsList, new List<VM_SPONSORLAR>());

            return list;
        }

        [HttpGet]
        [Route("GetSponsorlarById")]
        public VM_SPONSORLAR GetSponsorlarById(long id)
        {
            var spns = _spnsDal.Get(p => p.ID == id);
            var list = ObjectMapper.Map(spns, new VM_SPONSORLAR());

            return list;
        }

    }
}