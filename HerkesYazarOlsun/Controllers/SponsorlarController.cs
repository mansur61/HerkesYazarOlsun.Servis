
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorlarController : ControllerBase
    {

        private ISponsorlarDal spnsDal;


        public SponsorlarController(ISponsorlarDal spnsDal)
        {

            this.spnsDal = spnsDal;
        }

        [HttpPost]
        [Route("PostSponsorlar")]
        public ServiceResult PostSponsorlar(VM_SPONSORLAR spns)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            var spnsEntity = ObjectMapper.Map(spns, new Sponsorlar());

            try
            {

                spnsEntity = spnsDal.Add(spnsEntity);

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
            var spnsList = spnsDal.GetList().ToList();
            var list = ObjectMapper.MapList(spnsList, new List<VM_SPONSORLAR>());

            return list;
        }

        [HttpGet]
        [Route("GetSponsorlarById")]
        public VM_SPONSORLAR GetSponsorlarById(long id)
        {
            var spns = spnsDal.Get(p => p.ID == id);
            var list = ObjectMapper.Map(spns, new VM_SPONSORLAR());

            return list;
        }

    }
}