using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksBll : IBooksService
    {
        private readonly IBooksDal _booksDal;
        private readonly IFavBookDal _favoriBookDal;
        private readonly IUserAccessor _userAccessor;
        private readonly IBooksStarsDal _bookStarDal;
        private readonly IBooksCommentDal _booksCommentDal;
        private readonly IBooksDegerlendirmeDal _booksDegerlendirmeDal;

        public BooksBll(
            IBooksDal booksDal,
            IFavBookDal favoriBookDal,
            IUserAccessor userAccessor,
            IBooksStarsDal bookStarDal,
            IBooksCommentDal booksCommentDal,
            IBooksDegerlendirmeDal booksDegerlendirmeDal
        )
        {
            _booksDal = booksDal ?? throw new ArgumentNullException(nameof(booksDal));
            _favoriBookDal = favoriBookDal ?? throw new ArgumentNullException(nameof(favoriBookDal));
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            _bookStarDal = bookStarDal ?? throw new ArgumentNullException(nameof(bookStarDal));
            _booksCommentDal = booksCommentDal ?? throw new ArgumentNullException(nameof(booksCommentDal));
            _booksDegerlendirmeDal = booksDegerlendirmeDal ?? throw new ArgumentNullException(nameof(booksDegerlendirmeDal));
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
            return _booksDal.Ekle(book, _userAccessor.MAIL);
        }

        public FavoriBooks PostFavoriSaveBook(FavoriBooks fav)
        {
            return _favoriBookDal.Add(fav, 0);
        }

        public VM_BOOK_ISTATISTIKLER GetISTATISTIKLERBooksById(long id)
        {
            var istastk = new VM_BOOK_ISTATISTIKLER();

            // Star
            var starSonuc = _bookStarDal.GetList(book => book.BookaId == id)
                                        .GroupBy(p => p.LoginUserId)
                                        .ToList();
            istastk.ToplamYildiz = starSonuc.Count;

            // Favori
            var favSonuc = _favoriBookDal.GetAllQueryable(book => book.BOOKS_ID == id)
                                         .GroupBy(p => p.USER_ID)
                                         .ToList();
            istastk.ToplamBegeni = favSonuc.Count;

            // Comment
            var commentSonuc = _booksCommentDal.GetAllQueryable(book => book.BookId == id)
                                               .GroupBy(p => p.LoginUserId)
                                               .ToList();
            istastk.ToplamYorum = commentSonuc.Count;

            // Degerlendirme
            var degerlendirmeSonuc = _booksDegerlendirmeDal.GetList(book => book.BookId == id)
                                                            .GroupBy(p => p.LoginUserId)
                                                            .ToList();
            istastk.ToplamDegerlendirme = degerlendirmeSonuc.Count;

            return istastk;
        }

        public VM_Stars GetMaxStarBooksById(long id)
        {
            var keyValuePairs = new Dictionary<string, int>();
            var vM_BooksStars = new VM_Stars();
            var yildizlar = new List<int>();

            for (int star = 1; star <= 5; star++)
            {
                int count = _bookStarDal.GetList(p => p.StarPuani == star && p.BookaId == id).Count();
                yildizlar.Add(count);
                keyValuePairs.Add($"yildiz{star}", count);

                switch (star)
                {
                    case 1: vM_BooksStars.BirStarToplam = count; break;
                    case 2: vM_BooksStars.IkiStarToplam = count; break;
                    case 3: vM_BooksStars.UcStarToplam = count; break;
                    case 4: vM_BooksStars.DortStarToplam = count; break;
                    case 5: vM_BooksStars.BesStarToplam = count; break;
                }
            }

            var max = yildizlar.Max();
            foreach (var item in keyValuePairs)
            {
                if (item.Value == max)
                {
                    vM_BooksStars.HangiStar = item.Key;
                    vM_BooksStars.EnFazlaSitar = item.Value;
                    break;
                }
            }

            return vM_BooksStars;
        }

        public Books UpdateBook(Books book)
        {
            return _booksDal.Guncelle(book, _userAccessor.MAIL);
        }

        public void DeleteBook(int bookId)
        {
            _booksDal.Sil(bookId, _userAccessor.MAIL);
        }
    }
}
