
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksPagesService
    {
        List<BooksPages> GetBooksPagesList();
        BooksPages? GetBooksPages(long id);
        List<BooksPages> GetPagesByBooks(long bookID);
        BooksPages PostSaveBooksPages(BooksPages booksPages);
        BooksPages? PostUpdateBooksPages(VM_BOOKS_PAGES bookPageSayfa);

    }
}
