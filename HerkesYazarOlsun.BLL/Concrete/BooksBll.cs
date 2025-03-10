using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksBll : IBooksService
    {
        private readonly IBooksDal _booksDal;
        private readonly IUserAccessor userAccessor;
        private readonly IFavBookDal _favoriBookDal;
        public BooksBll(IBooksDal booksDal, IFavBookDal favoriBookDal, IUserAccessor userAccessor)
        {
            _booksDal = booksDal;
            // _favoriDal = favoriDal;
            _favoriBookDal = favoriBookDal;
            this.userAccessor = userAccessor;

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
            return _booksDal.Ekle(book, userAccessor.MAIL);
        }

        public FavoriBooks PostFavoriSaveBook(FavoriBooks fav)
        {
            return _favoriBookDal.Add(fav, 0);
        }

        public VM_BOOK_ISTATISTIKLER GetISTATISTIKLERBooksById(long id)
        {
            VM_BOOK_ISTATISTIKLER istastk = new VM_BOOK_ISTATISTIKLER();

            IBooksStarsDal bookStar = InstanceFactory.GetInstance<IBooksStarsDal>();
            var starSonuc = bookStar.GetList(book => book.ID == id).GroupBy(p => p.LoginUserId).ToList();
            istastk.ToplamYildiz = starSonuc.Count; // toplam LoginUserId gruba göre ilgili kitaba kaç farklı kişi yıldız vermiş

            //----------------
            IFavBookDal bookFav = InstanceFactory.GetInstance<IFavBookDal>();
            var favSonuc = bookFav.GetAllQueryable(book => book.ID == id).GroupBy(p => p.USER_ID).ToList();
            istastk.ToplamBegeni = favSonuc.Count; // toplam USER_ID gruba göre ilgili kitaba kaç farklı kişi favorilere ekledi  


            //----------------
            IBooksCommentDal bookComment = InstanceFactory.GetInstance<IBooksCommentDal>();
            var commentSonuc = bookComment.GetAllQueryable(book => book.ID == id).GroupBy(p => p.LoginUserId).ToList();
            istastk.ToplamYorum = commentSonuc.Count; // toplam LoginUserId gruba göre ilgili kitaba kaç farklı kişi yorum ekledi  

            //----------------
            IBooksDegerlendirmeDal bookDegerlendirme = InstanceFactory.GetInstance<IBooksDegerlendirmeDal>();
            var degerlendirmeSonuc = bookDegerlendirme.GetList(book => book.ID == id).GroupBy(p => p.LoginUserId).ToList();
            istastk.ToplamDegerlendirme = degerlendirmeSonuc.Count; // toplam LoginUserId gruba göre ilgili kitabı kaç farklı kişi değelendirmiş

            return istastk;
        }
        public VM_Stars GetMaxStarBooksById(long id)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            VM_Stars vM_BooksSatars = new VM_Stars();
            List<int> _yildizlar = new List<int>();

            IBooksStarsDal bookStar = InstanceFactory.GetInstance<IBooksStarsDal>();

            int yildiz1 = bookStar.GetList(p => p.StarPuani == 1 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz1);
            vM_BooksSatars.BirStarToplam = yildiz1;
            keyValuePairs.Add("yildiz1", yildiz1);

            int yildiz2 = bookStar.GetList(p => p.StarPuani == 2 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz2);
            keyValuePairs.Add("yildiz2", yildiz2);
            vM_BooksSatars.IkiStarToplam = yildiz2;

            int yildiz3 = bookStar.GetList(p => p.StarPuani == 3 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz3);
            keyValuePairs.Add("yildiz3", yildiz3);
            vM_BooksSatars.UcStarToplam = yildiz3;

            int yildiz4 = bookStar.GetList(p => p.StarPuani == 4 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz4);
            keyValuePairs.Add("yildiz4", yildiz4);
            vM_BooksSatars.DortStarToplam = yildiz4;

            int yildiz5 = bookStar.GetList(p => p.StarPuani == 5 && p.BookaId == id).Count();
            _yildizlar.Add(yildiz5);
            keyValuePairs.Add("yildiz5", yildiz5);
            vM_BooksSatars.BesStarToplam = yildiz5;

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
            return _booksDal.Guncelle(book, userAccessor.MAIL);
        }
        public void DeleteBook(int bookId)
        {
            _booksDal.Sil(bookId, userAccessor.MAIL);
        }

    }
}
