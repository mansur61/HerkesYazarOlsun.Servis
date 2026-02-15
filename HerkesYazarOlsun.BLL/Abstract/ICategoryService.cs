using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface ICarouselService
    {
        List<VM_CAROUSEL_DUYURU> GetDuyurular();
    }
}
