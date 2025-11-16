using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class OdemeSponsorlariBll : IOdemeSponsorlariService
    {

        private IOdemeSponsorlariDal odemeSpnsDal;
        public OdemeSponsorlariBll(IOdemeSponsorlariDal _odemeDal)
        {
            odemeSpnsDal = _odemeDal;
        }

        public OdemeSponsorlari Add(OdemeSponsorlari oSpns, long tcNo)
        {
            return odemeSpnsDal.Add(oSpns, tcNo);
        }

    }
}
