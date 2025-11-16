using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class SponsorlarBll : ISponsorlarService
    {

        private ISponsorlarDal _spnsDal;
        public SponsorlarBll(ISponsorlarDal _spnsDal)
        {
            this._spnsDal = _spnsDal;
        }

        public List<VM_SPONSORLAR> GetSponsorlar()
        {
            var spnsList = _spnsDal.GetList().ToList();
            var list = ObjectMapper.MapList(spnsList, new List<VM_SPONSORLAR>());

            return list;
        }

        public VM_SPONSORLAR GetSponsorlarById(long id)
        {
            var spns = _spnsDal.Get(p => p.ID == id);
            var list = ObjectMapper.Map(spns, new VM_SPONSORLAR());

            return list;
        }

        public Sponsorlar? Add(Sponsorlar sps)
        {
            return _spnsDal.Add(sps); 
        }

         

    }
}
