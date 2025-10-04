using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class TaleplerController : BaseApiController
    {
        ITaleplerDal _taleplerDal;
        public TaleplerController( ITaleplerDal taleplerDal, IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor configuration)
            : base(userAccessor, unitOfWork, configuration)
        {
            _taleplerDal = taleplerDal;
        }

        [HttpPost]
        [Route("TalepKaydet")]
        public ServiceResult TalepKaydet(VM_TALEPLER talepler)
        {
            ServiceResult resut = new ServiceResult(state:MessageResultState.SUCCESS);
            try
            {
                var entity = ObjectMapper.Map<VM_TALEPLER, Talepler>(talepler);
                var talep = _taleplerDal.Add(entity);
                resut.Result = talep;
                resut.Message = "Talebiniz Alınmıştır.";
            }
            catch (Exception)
            {
                resut.State = MessageResultState.ERROR;
            }

            return resut;
        }

    }
}
