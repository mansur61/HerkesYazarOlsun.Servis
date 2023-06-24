using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksPagesBll : IBooksPagesService
    {
        private readonly IBooksPagesDal _booksPagesDal;
        public BooksPagesBll(IBooksPagesDal BooksPagesDal)
        {
            _booksPagesDal = BooksPagesDal;
        }

        public BooksPages? GetBooksPages(long id)
        {
            return _booksPagesDal.GetAllQueryable(p => p.ID == id).FirstOrDefault();

        }

        public List<BooksPages> GetBooksPagesList()
        {
            return _booksPagesDal.GetAll();
        }

        public BooksPages PostSaveBooksPages(BooksPages book)
        {
            return _booksPagesDal.Add(book, 0);
        }

       

    }
}
