
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.BLL.Abstract
{
    public interface IBooksPagesService
    {
        List<BooksPages> GetBooksPagesList();
        Task<VM_BOOKS_PAGES> ModelIlgiliKitapSayfaDosyalariDoldur(VM_BOOKS_PAGES? inputPage);
        Task ModelIlgiliKitapSayfaDosyaSil(string dosyaYolu);
        BooksPages? GetBooksPages(long id);
        List<BooksPages> GetPagesByBooks(long bookID);
        BooksPages PostSaveBooksPages(BooksPages booksPages);
        BooksPages? PostUpdateBooksPages(VM_BOOKS_PAGES bookPageSayfa);

    }
}
