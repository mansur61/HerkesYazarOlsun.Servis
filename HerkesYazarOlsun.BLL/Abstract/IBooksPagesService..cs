
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksPagesService
    {
        List<BooksPages> GetBooksPagesList();
        BooksPages? GetBooksPages(long id);

        BooksPages PostSaveBooksPages(BooksPages booksPages);
       
        
    }
}
