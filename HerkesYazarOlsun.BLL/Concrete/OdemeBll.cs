using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class OdemeBll : IOdemeService
    {

        private IOdemeDal _odemeDal;
        public OdemeBll(IOdemeDal odemeDal)
        {
            _odemeDal = odemeDal;
        }

        public Odeme Ekle(Odeme kart, string? mail)
        {
            return _odemeDal.Ekle(kart, mail);
        }

    }
}
