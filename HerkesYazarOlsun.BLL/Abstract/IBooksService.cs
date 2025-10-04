
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksService
    {
        List<Books> GetBooksList();
        Books GetBooks(long id);
        Books UpdateBook(Books book);
        void DeleteBook(int bookId);
        Books PostSaveBook(Books books);

        //FAVORILER PostFavoriSaveBook(FAVORILER fav);
        FavoriBooks PostFavoriSaveBook(FavoriBooks fav); 


    }
}
