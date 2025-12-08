using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.DataLayer;
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
        private BooksPagesAddValidator _booksPagesAddValidator;

        public BooksPagesController(IBooksPagesService booksPagesService, IUserAccessor userAccessor, 
            IUnitOfWork unitOfWork, IHttpContextAccessor configuration, BooksPagesAddValidator booksPagesAddValidator)
            : base(userAccessor, unitOfWork, configuration)
        {
            _booksPagesService = booksPagesService;
            _booksPagesAddValidator = booksPagesAddValidator;
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
        public async Task<ServiceResult<BooksPages>> PostSaveBooksPages([FromForm] VM_BOOKS_PAGES bookPages)
        {

            ServiceResult<BooksPages> result = new ServiceResult<BooksPages>(state: MessageResultState.SUCCESS);

            if (!bookPages.isWordPDF) // bu durumu ve validasyoları kitap ekleme durumnu pdf veya word değilse yap
            { 
                var sonuc = _booksPagesAddValidator.Validate(bookPages);

                if (!sonuc!.IsValid)
                {
                    foreach (var item in sonuc.Errors)
                    {
                        result.Message += item.ErrorMessage + ",";
                    }
                    result.State = MessageResultState.WARNING;
                    return result;
                }
            }

            bookPages = await _booksPagesService.ModelIlgiliKitapSayfaDosyalariDoldur(bookPages);
            var booksPage = ObjectMapper.Map(bookPages, new BooksPages());
            booksPage.BookId = bookPages.BookId;

            try
            {
                var getBookPages = _booksPagesService.PostSaveBooksPages(booksPage);
                result.Result = getBookPages;
            }
            catch (Exception ex)
            {
                result.State = MessageResultState.ERROR;
                result.Message = ex.Message ;
                await _booksPagesService.ModelIlgiliKitapSayfaDosyaSil(booksPage.PageFoto);

                return result;
            }
            


            return result;
        }

        [HttpPost]
        [Route("PostUpdateBooksPages")]
        public async Task<ServiceResult> PostUpdateBooksPages([FromForm] VM_BOOKS_PAGES pages)
        {
            ServiceResult sonuc = new ServiceResult(state: MessageResultState.SUCCESS);
            pages = await _booksPagesService.ModelIlgiliKitapSayfaDosyalariDoldur(pages);

            var guncellenecekSayfa =  _booksPagesService.PostUpdateBooksPages(pages);
            if(guncellenecekSayfa == null)
            {
                sonuc.State = MessageResultState.ERROR;
            }
            return sonuc;
        }
    }
}
