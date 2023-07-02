
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksPagesService
    {
        List<BooksPages> GetBooksPagesList();
        BooksPages? GetBooksPages(long id);
        List<BooksPages> GetPagesByBooks(long bookID);
        BooksPages PostSaveBooksPages(BooksPages booksPages);
       
        
    }
}
