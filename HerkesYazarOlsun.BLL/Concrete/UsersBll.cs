using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class UsersBll : IUsersService
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

        public VM_Stars GetMaxStarWriterById(long id)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            VM_Stars vM_WriterSatars = new VM_Stars();
            List<int> _yildizlar = new List<int>();

            IWriterStarsDal yazarStar = InstanceFactory.GetInstance<IWriterStarsDal>();

            int yildiz1 = yazarStar.GetList(p => p.StarPuani == 1 && p.YazarId == id).Count();
            _yildizlar.Add(yildiz1);
            keyValuePairs.Add("yildiz1", yildiz1);
            vM_WriterSatars.BirStarToplam = yildiz1;

            int yildiz2 = yazarStar.GetList(p => p.StarPuani == 2 && p.YazarId == id).Count();
            _yildizlar.Add(yildiz2);
            keyValuePairs.Add("yildiz2", yildiz2);
            vM_WriterSatars.IkiStarToplam = yildiz2;

            int yildiz3 = yazarStar.GetList(p => p.StarPuani == 3 && p.YazarId == id).Count();
            _yildizlar.Add(yildiz3);
            keyValuePairs.Add("yildiz3", yildiz3);
            vM_WriterSatars.UcStarToplam = yildiz3;

            int yildiz4 = yazarStar.GetList(p => p.StarPuani == 4 && p.YazarId == id).Count();
            _yildizlar.Add(yildiz4);
            keyValuePairs.Add("yildiz4", yildiz4);
            vM_WriterSatars.DortStarToplam = yildiz4;

            int yildiz5 = yazarStar.GetList(p => p.StarPuani == 5 && p.YazarId == id).Count();
            _yildizlar.Add(yildiz5);
            keyValuePairs.Add("yildiz5", yildiz5);
            vM_WriterSatars.BesStarToplam = yildiz5;


            var max = _yildizlar.Max();

            foreach (var item in keyValuePairs)
            {
                if (item.Value == max)
                {
                    vM_WriterSatars.HangiStar = item.Key;
                    vM_WriterSatars.EnFazlaSitar = item.Value;
                }
            }

            return vM_WriterSatars;
        }
    }
}
