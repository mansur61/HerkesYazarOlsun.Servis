using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksService booksService;
        public BooksController(IBooksService _booksService)
        {
            booksService = _booksService;
        }

        [HttpGet]
        [Route("GetBooks")]
        public Books GetBooks(long id)
        {

            var getBook = booksService.GetBooks(id);

            return getBook;
        }

        [HttpGet]
        [Route("GetBooksList")]
        public List<Books> GetBooksList()
        {
            var getBookList = booksService.GetBooksList();

            return getBookList;
        }

        [HttpPost]
        [Route("PostSaveBook")]
        public Books PostSaveBook(Books book)
        {
            var getBook = booksService.PostSaveBook(book);

            return getBook;
        }

    }
}
