using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksBll : IBooksService
    {
        private readonly IBooksDal _booksDal;
        //private readonly IFavorilerDal _favoriDal;
        private readonly IFavBookDal _favoriBookDal;
        public BooksBll(IBooksDal booksDal, IFavBookDal favoriBookDal)
        {
            _booksDal = booksDal;
           // _favoriDal = favoriDal;
            _favoriBookDal = favoriBookDal;
        }

        public Books? GetBooks(long id)
        {
            return _booksDal.GetAllQueryable(p => p.ID == id).FirstOrDefault();

        }

        public List<Books> GetBooksList()
        {
            return _booksDal.GetAll();
        }
        public Books PostSaveBook(Books book)
        {
            return _booksDal.Add(book, 0);
        }

        public FavoriBooks PostFavoriSaveBook(FavoriBooks fav)
        {
            return _favoriBookDal.Add(fav, 0);
        }
        public VM_Stars GetMaxStarBooksById(long id)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            VM_Stars vM_BooksSatars = new VM_Stars();
            List<int> _yildizlar = new List<int>();

            IBooksStarsDal bookStar = InstanceFactory.GetInstance<IBooksStarsDal>();

            int yildiz1 = bookStar.GetList(p => p.StarPuani == 1 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz1);
            keyValuePairs.Add("yildiz1", yildiz1);
            int yildiz2 = bookStar.GetList(p => p.StarPuani == 2 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz2);
            keyValuePairs.Add("yildiz2", yildiz2);
            int yildiz3 = bookStar.GetList(p => p.StarPuani == 3 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz3);
            keyValuePairs.Add("yildiz3", yildiz3);
            int yildiz4 = bookStar.GetList(p => p.StarPuani == 4 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz4);
            keyValuePairs.Add("yildiz4", yildiz4);
            int yildiz5 = bookStar.GetList(p => p.StarPuani == 5 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz5);
            keyValuePairs.Add("yildiz5", yildiz5);

            var max = _yildizlar.Max();

            foreach (var item in keyValuePairs)
            {
                if (item.Value == max)
                {
                    vM_BooksSatars.HangiStar = item.Key;
                    vM_BooksSatars.EnFazlaSitar = item.Value;
                }
            }

            return vM_BooksSatars;
        }
        public Books UpdateBook(Books book)
        {
            return _booksDal.Update(book, 0);
        }
    }
}
