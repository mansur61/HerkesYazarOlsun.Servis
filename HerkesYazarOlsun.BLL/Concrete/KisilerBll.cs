using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Concrete.EntityFramework;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class KisilerBll : IKisilerService
    {
        private readonly IKisilerDal _kisilerDal;
        public KisilerBll(IKisilerDal kisilerDal)
        {
            _kisilerDal = kisilerDal;
        }

        public List<KISILER> GetKullanicilar()
        {
            return _kisilerDal.GetAll();
        }
    }
}
