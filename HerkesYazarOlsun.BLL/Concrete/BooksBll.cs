using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.EntityFrameworkCore;

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
            
            return _booksDal.GetAllQueryableNoTracking(p => p.ID == id).
                Include(b => b.Yazar)
                    .ThenInclude(c => c.Profil)
                .Include(b => b.Categori)
                    .ThenInclude(c => c.CategoryYayinAyarlari)
                .Include(b => b.Categori)
                .Include(b => b.YayinAyar)
                .Include(b => b.BooksPageList)
                .Include(b => b.BooksComments)
                .Include(b => b.BooksStars)
                .Include(b => b.FavoriBooks)
                .Include(b => b.BooksDegerlendirme)
                . FirstOrDefault();
        }

        public VM_Stars CalculateMaxStar(Books book)
        {
            var vM_BooksStars = new VM_Stars();
            if (book == null || book.BooksStars == null || !book.BooksStars.Any())
                return vM_BooksStars;

            var groups = book.BooksStars
                .GroupBy(s => s.StarPuani)
                .Select(g => new { Star = g.Key, Count = g.Count() })
                .ToList();

            vM_BooksStars.BirStarToplam = groups.FirstOrDefault(g => g.Star == 1)?.Count ?? 0;
            vM_BooksStars.IkiStarToplam = groups.FirstOrDefault(g => g.Star == 2)?.Count ?? 0;
            vM_BooksStars.UcStarToplam = groups.FirstOrDefault(g => g.Star == 3)?.Count ?? 0;
            vM_BooksStars.DortStarToplam = groups.FirstOrDefault(g => g.Star == 4)?.Count ?? 0;
            vM_BooksStars.BesStarToplam = groups.FirstOrDefault(g => g.Star == 5)?.Count ?? 0;

            var maxGroup = groups.OrderByDescending(g => g.Count).FirstOrDefault();
            if (maxGroup != null)
            {
                vM_BooksStars.HangiStar = $"yildiz{maxGroup.Star}";
                vM_BooksStars.EnFazlaSitar = maxGroup.Count;
            }

            return vM_BooksStars;
        }

        public VM_BOOK_ISTATISTIKLER CalculateBookIstatistic(Books bookEntity)
        {
            if(bookEntity == null)
            {
                return new VM_BOOK_ISTATISTIKLER();
            }
            var istatistik = new VM_BOOK_ISTATISTIKLER
            {
                ToplamYildiz = bookEntity.BooksStars?
            .GroupBy(s => s.LoginUserId)
            .Count() ?? 0,

                ToplamBegeni = bookEntity.FavoriBooks?
            .GroupBy(f => f.UserId)
            .Count() ?? 0,

                ToplamYorum = bookEntity.BooksComments?
            .GroupBy(c => c.LoginUserId)
            .Count() ?? 0,

                ToplamDegerlendirme = bookEntity.BooksDegerlendirme?
            .GroupBy(d => d.LoginUserId)
            .Count() ?? 0
            };

            return istatistik;
        }

        public List<Books> GetBooksList()
        {
            var list = _booksDal
                .GetAllQueryable()
                .Include(b => b.Yazar)
                    .ThenInclude(c => c.Profil)
                .Include(b => b.Categori)
                     .ThenInclude(c => c.CategoryYayinAyarlari)
                .Include(b => b.YayinAyar)
                .Include(b => b.BooksPageList)
                .Include(b => b.BooksComments)
                .Include(b => b.BooksStars)
                .Include(b => b.FavoriBooks)
                .Include(b => b.BooksDegerlendirme)
                .ToList();
            return list;
        }

        public Books PostSaveBook(Books book)
        {
            return _booksDal.Ekle(book, _userAccessor.MAIL);
        }

        public FavoriBooks PostFavoriSaveBook(FavoriBooks fav)
        {
            return _favoriBookDal.Add(fav, 0);
        }
        public List<FavoriBooks> GetFavoriBooksByuserId(long? userId)
        {
            return _favoriBookDal.GetAllQueryableNoTracking(p => p.UserId == userId).ToList();
        }
        

        public Books UpdateBook(Books book)
        {
            return _booksDal.Guncelle(book, _userAccessor.MAIL);
        }

        public void DeleteBook(int bookId)
        {
            _booksDal.Sil(bookId, _userAccessor.MAIL);
        }

        public bool DeleteBookById(int bookId)
        {
            try
            {
                _booksDal.Sil(bookId, _userAccessor.MAIL);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
