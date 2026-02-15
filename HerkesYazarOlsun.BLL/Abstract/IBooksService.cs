
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksService
    {
        List<Books> GetBooksList();
        IQueryable<Books> GetBooksQueryable();
        VM_Stars CalculateMaxStar(Books book);
        VM_BOOK_ISTATISTIKLER CalculateBookIstatistic(Books bookEntity);
        Books GetBooks(long id);
        Books UpdateBook(Books book);
        void  DeleteBook(int bookId);
        bool  DeleteBookById(int bookId);
        Books PostSaveBook(Books books);

        //FAVORILER PostFavoriSaveBook(FAVORILER fav);
        FavoriBooks PostFavoriSaveBook(FavoriBooks fav);
        List<FavoriBooks> GetFavoriBooksByuserId(long? userId);

    }
}
