using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface ISponsorlarService
    {
        List<VM_SPONSORLAR> GetSponsorlar();
        VM_SPONSORLAR GetSponsorlarById(long id);
        Sponsorlar? Add(Sponsorlar sps);
    }
}
