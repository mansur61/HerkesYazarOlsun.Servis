using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksPagesBll : IBooksPagesService
    {
        private readonly IBooksPagesDal _booksPagesDal;
        private IUserAccessor _userAccessor;
        public BooksPagesBll(IBooksPagesDal BooksPagesDal, IUserAccessor userAccessor)
        {
            _booksPagesDal = BooksPagesDal;
            _userAccessor = userAccessor;
        }

        public BooksPages? GetBooksPages(long id)
        {
            return _booksPagesDal.GetAllQueryable(p => p.ID == id).FirstOrDefault();

        }

        public List<BooksPages> GetPagesByBooks(long bookID)
        {
            return _booksPagesDal.GetAllQueryable(p => p.BooksId == bookID).ToList();

        }
        public List<BooksPages> GetBooksPagesList()
        {
            return _booksPagesDal.GetAll();
        }

        public BooksPages PostSaveBooksPages(BooksPages book)
        {
          
            return _booksPagesDal.Ekle(book, _userAccessor.MAIL);
        }

        public BooksPages? PostUpdateBooksPages(VM_BOOKS_PAGES bookPageSayfa)
        {
            var guncellenecekSayfa =  GetBooksPages(bookPageSayfa.ID);
            if(guncellenecekSayfa != null)
            {
                guncellenecekSayfa!.PageWrite = bookPageSayfa.PageWrite;
                return _booksPagesDal.Guncelle(guncellenecekSayfa, _userAccessor.MAIL);
            }
            else
            {
                return null;
            }
        } 


        

    }
}
