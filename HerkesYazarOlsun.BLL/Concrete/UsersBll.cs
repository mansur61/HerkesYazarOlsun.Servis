using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class UsersBll : IUsersBll
    {
        private readonly IUsersDal _kisilerDal;
        public UsersBll(IUsersDal kisilerDal)
        {
            _kisilerDal = kisilerDal;
        }

        public List<Users> GetKullanicilar()
        {
            return _kisilerDal.GetAll();
        }
    }
}
