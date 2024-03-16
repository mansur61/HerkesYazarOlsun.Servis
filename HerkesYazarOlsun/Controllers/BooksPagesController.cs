using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksPagesController : BaseApiController
    {
        private IBooksPagesService _booksPagesService;
       
        public BooksPagesController(IBooksPagesService booksPagesService, IUserAccessor userAccessor):base(userAccessor) {
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

        [HttpPost]
        [Route("PostUpdateBooksPages")]
        public ServiceResult PostUpdateBooksPages(VM_BOOKS_PAGES pages)
        {
            ServiceResult sonuc = new ServiceResult(state: MessageResultState.SUCCESS);
            var guncellenecekSayfa =  _booksPagesService.PostUpdateBooksPages(pages);
            if(guncellenecekSayfa == null)
            {
                sonuc.State = MessageResultState.ERROR;
            }
            return sonuc;
        }
    }
}
