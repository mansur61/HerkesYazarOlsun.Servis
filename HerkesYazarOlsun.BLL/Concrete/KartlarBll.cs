using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
namespace HerkesYazarOlsun.BLL.Concrete
{
    public class KartlarBll : IKartlarService
    {

       private IKartlarDal _kartlarDal;
        public KartlarBll(IKartlarDal kartlarDal)
        {
            _kartlarDal = kartlarDal;
        }

        public Kartlar Ekle(Kartlar kart,string? mail)
        {
           return _kartlarDal.Ekle(kart, mail);
        }

    }
}
