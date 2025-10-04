using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
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
            return _booksDal.GetAllQueryable(p => p.ID == id).FirstOrDefault();
        }

        public List<Books> GetBooksList()
        {
            var list = _booksDal
                .GetAllQueryable()
                .Include(b => b.User)
                    .ThenInclude(c => c.Profil)
                .Include(b => b.Categories)
                .Include(b => b.BookYayinAyari)
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
