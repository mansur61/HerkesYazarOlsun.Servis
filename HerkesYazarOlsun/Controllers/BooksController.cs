using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [Route("TumKitaplar")]
        public List<Books> TumKitaplar(VM_ARAMA_INPUT arama)
        {
            List < Books > getBookList = new List < Books >();
            if (!string.IsNullOrEmpty(arama.KITAP_ADI))
            {
                getBookList = getBookList.Where(p => p.Name.Contains(arama.KITAP_ADI!)).ToList();
            }
            else
            {
                getBookList = booksService.GetBooksList();
            }

            return getBookList;
        }

        [HttpPost]
        [Route("PostSaveBook")]
        public Books PostSaveBook(Books book)
        {
            var getBook = booksService.PostSaveBook(book);

            return getBook;
        }


        [HttpPost]
        [Route("PostFavoriSaveBook")]
        public FAVORILER PostFavoriSaveBook(FAVORILER fav)
        {
            var getFav = booksService.PostFavoriSaveBook(fav);

            return getFav;
        }

        [HttpPost]
        [Route("UpdateBook")]
        public Books UpdateBook(Books book)
        {
            var getBook = booksService.UpdateBook(book);

            return getBook;
        }

    }
}
