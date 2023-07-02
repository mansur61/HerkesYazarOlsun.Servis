using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksPagesController : ControllerBase
    {
        private IBooksPagesService _booksPagesService;
        public BooksPagesController(IBooksPagesService booksPagesService) {
            _booksPagesService = booksPagesService;
        }

        [HttpGet]
        [Route("GetBooksPages")]
        public BooksPages? GetBooksPages(long id)
        {
           
            var getBookPages = _booksPagesService.GetBooksPages(id);

            return getBookPages;
        }

        [HttpGet]
        [Route("GetPagesByBooks")]
        public List<BooksPages>? GetPagesByBooks(long bookID)
        {

            var getBookPagesList = _booksPagesService.GetPagesByBooks(bookID);

            return getBookPagesList;
        }

        [HttpGet]
        [Route("GetBooksPagesList")]
        public List<BooksPages> GetBooksPagesList()
        {
            var getBookPagesList = _booksPagesService.GetBooksPagesList();

            return getBookPagesList;
        }

        [HttpPost]
        [Route("PostSaveBooksPages")]
        public BooksPages PostSaveBooksPages(BooksPages book)
        {
            var getBookPages = _booksPagesService.PostSaveBooksPages(book);

            return getBookPages;
        }
    }
}
