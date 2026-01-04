using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class UsersBll : IUsersService
    {
        private readonly IUsersDal _kisilerDal;
        private readonly IWriterStarsDal _writerStarsDal;
        public UsersBll(IUsersDal kisilerDal, IWriterStarsDal writerStarsDal)
        {
            _kisilerDal = kisilerDal;
            _writerStarsDal = writerStarsDal;
        }

        public Users? Ekle(Users usr, string? mail)
        {
            return _kisilerDal.Ekle(usr, mail); ;
        }

        public Users? Guncelle(Users usr, long tck)
        {
            return _kisilerDal.Update(usr, tck);
        }
        public Users? Get(long LoginUserId)
        {
            var sonuc = _kisilerDal.GetAllQueryable(p => p.ID == LoginUserId)
                .Include(b => b.Profil)
                .Include(b => b.WriterStarsLoginList)
                .Include(b => b.WriterFollowYazarList)
                .Include(b => b.WriterFollowLoginList)                
                .FirstOrDefault();
            return sonuc;
        }

        public Users? GetMail(string mail)
        {
            var sonuc = _kisilerDal.GetAllQueryableNoTracking(p => p.EMAIL == mail).Include(b => b.Profil)
                .Include(b => b.WriterStarsLoginList)
                .Include(b => b.WriterFollowLoginList).SingleOrDefault();
            return sonuc;
        }

        public Users? GetUserrName(string username)
        {
            var sonuc = _kisilerDal.GetAllQueryableNoTracking(p => p.SURNAME == username).Include(b => b.Profil).Include(b => b.WriterStarsLoginList).Include(b => b.WriterFollowLoginList).SingleOrDefault();
            return sonuc;
        }
        public List<Users> GetKullanicilar()
        {
            // Profil dahil olarak çekmek
            //var users = _kisilerDal.GetAllWithIncludes(u => u.Profil); 
            //return users;
            var list = _kisilerDal
                .GetAllQueryable()
                .Include(b => b.Profil)
                .Include(b => b.FavoriYazarlarList)
                .Include(b => b.WriterStarsLoginList)
                .Include(b => b.WriterStarsYazarList)
                .Include(b => b.WriterFollowLoginList)
                .ToList();

            return list;
        }

        public VM_Stars GetMaxStarWriterById(long id)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            VM_Stars vM_WriterSatars = new VM_Stars();
            List<int> _yildizlar = new List<int>();

            IWriterStarsDal yazarStar = _writerStarsDal;

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
                if(item.Value == 0)
                {
                    vM_WriterSatars.HangiStar = null;
                    vM_WriterSatars.EnFazlaSitar = item.Value;
                }
                else if (item.Value == max)
                {
                    vM_WriterSatars.HangiStar = item.Key;
                    vM_WriterSatars.EnFazlaSitar = item.Value;
                }
            }

            return vM_WriterSatars;
        }
    }
}
