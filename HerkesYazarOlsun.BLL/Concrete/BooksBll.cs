using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksBll : IBooksService
    {
        private readonly IBooksDal _booksDal;
        private readonly IFavorilerDal _favoriDal;
        public BooksBll(IBooksDal booksDal, IFavorilerDal favoriDal)
        {
            _booksDal = booksDal;
            _favoriDal = favoriDal;
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

        public FAVORILER PostFavoriSaveBook(FAVORILER fav)
        {
            return _favoriDal.Add(fav, 0);
        }

        public Books UpdateBook(Books book)
        {
            return _booksDal.Update(book, 0);
        }
    }
}
