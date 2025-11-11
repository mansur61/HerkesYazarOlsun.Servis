using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseApiController
    {
        private IBooksService booksService;
        private IBooksStarsService booksStarsService;
        private IBooksDegerlendirmeService booksDegerlendirmeService;
        private ICategoryService _categoryService;
        private IBooksPagesService booksPagesService;
        private readonly ILogger<BooksController> _logger;
        private IFtpService _ftpService;
        private readonly BookDegerlendirmeValidator _bookDegerlendirmevalidator;
        private readonly BooksCommentValidator _commentValidator;
        private BooksAddValidator _booksAddValidator;
        private CheckBooksValidator _checkBooksValidator;
        private BooksStarsValidator _booksStarsValidator;
        public BooksController(IBooksService _booksService, IBooksPagesService _booksPagesService, ICategoryService categoryService,
            IFtpService ftpService, ILogger<BooksController> logger,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, 
            BookDegerlendirmeValidator bookDegerlendirmevalidator, BooksCommentValidator commentValidator,
            BooksAddValidator booksAddValidator, CheckBooksValidator checkBooksValidator, BooksStarsValidator booksStarsValidator, 
            IBooksStarsService booksStarsService, IBooksDegerlendirmeService booksDegerlendirmeService   )
            : base(userAccessor, unitOfWork, httpContextAccessor)
        {
            booksService = _booksService;
            booksPagesService = _booksPagesService;
            _categoryService = categoryService;
            _ftpService = ftpService;
            _logger = logger;
            _bookDegerlendirmevalidator = bookDegerlendirmevalidator;
            _commentValidator = commentValidator;
            _booksAddValidator = booksAddValidator;
            _checkBooksValidator = checkBooksValidator;
            _booksStarsValidator = booksStarsValidator;
            this.booksStarsService = booksStarsService;
            this.booksDegerlendirmeService = booksDegerlendirmeService;
        }

        [HttpGet]
        [Route("GetBooks")]
        public VM_BOOKS GetBooks(long id)
        {
            var getBook = booksService.GetBooks(id);
            var vmGetBook = ObjectMapper.Map(getBook, new VM_BOOKS());
            
            vmGetBook.Stars = booksService.CalculateMaxStar(getBook);
            vmGetBook.iSTATISTIK = booksService.CalculateBookIstatistic(getBook); 

            return vmGetBook;
        }

        [HttpGet]
        [Route("GetCategories")]
        public List<VM_CATEGORI> GetCategories()
        { 
            var cats = _categoryService.GetCategories(); 
            var vmcatsList = ObjectMapper.MapList(cats, new List<VM_CATEGORI>());
            return vmcatsList;
        }

        [HttpGet]
        [Route("GetBooksList")]
        public VM_BOOKS_DETAIL GetBooksList()
        {
            VM_BOOKS_DETAIL vmBookDetay = new VM_BOOKS_DETAIL();
            var getBookList = booksService.GetBooksList();
            var list = getBookList.Where(p => p.IS_DELETED == 0).ToList();

            var vmBookList = ObjectMapper.MapList(list, new List<VM_BOOKS>());
            foreach (var item in vmBookList)
            {
                var bookEntity = getBookList.First(b => b.ID == item.ID);
                if (bookEntity == null) continue;

                item.Stars = booksService.CalculateMaxStar(bookEntity);
                item.iSTATISTIK = booksService.CalculateBookIstatistic(bookEntity);
            }
            vmBookDetay.VMBooksList = vmBookList;
            return vmBookDetay;
        }
 
        [HttpPost]
        [Route("PostBooksStars")]
        public ServiceResult<BooksStars> PostBooksStars(BooksStars star)
        {
            ServiceResult<BooksStars> result = new ServiceResult<BooksStars>(state: MessageResultState.SUCCESS); 
             
            var sonuc = _booksStarsValidator.Validate(star);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }

                result.State = MessageResultState.ERROR;
                return result;
            }


            try
            {
                star = booksStarsService.Ekle(star,MAIL);
             
                result.State = MessageResultState.SUCCESS;
                return result;

            }
            catch (Exception)
            {
                result.Message = "Kitap yıldız ekleme başarısız";
                result.State = MessageResultState.ERROR;

            }

            result.Result = star;
            return result;
        }

        [HttpPost]
        [Route("PostBooksDegerlendirme")]
        public ServiceResult PostBooksDegerlendirme(VM_BOOKS_DEGERLENDIRME degerlendirme)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS); 
             
            var sonuc = _bookDegerlendirmevalidator.Validate(degerlendirme);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }
                result.State = MessageResultState.ERROR;
                return result;
            }

            BooksDegerlendirme booksDegerlendirme = ObjectMapper.Map(degerlendirme, new BooksDegerlendirme());
            try
            {
                booksDegerlendirmeService.Ekle(booksDegerlendirme,MAIL); 
                result.State = MessageResultState.SUCCESS;
                return result;
            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }

            return result;
        }

        [HttpPost]
        [Route("PostBooksComments")]
        public ServiceResult PostBooksComments(VM_BOOKS_COMMENT mesajlar)
        {
            ServiceResult result = new ServiceResult(state: MessageResultState.SUCCESS);
            IBooksCommentService booksCommentDal = InstanceFactory.GetInstance<IBooksCommentService>().Service;
             
            var sonuc = _commentValidator.Validate(mesajlar);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }
                result.State = MessageResultState.ERROR;
                return result;
            }

            BooksComment booksDegerlendirme = ObjectMapper.Map(mesajlar, new BooksComment());
            try
            {
                booksCommentDal.Add(booksDegerlendirme,YETKILITCNO);
              
                result.State = MessageResultState.SUCCESS;
                result.Message = "Yorum başarıyla yapıldı";
                return result;
            }
            catch (Exception)
            {
                result.Message = "";
                result.State = MessageResultState.ERROR;
            }

            return result;
        }         

      
 

        [HttpGet]
        [Route("GetDegerlendirmelerBooksById")]
        public List<VM_BOOKS_DEGERLENDIRME> GetDegerlendirmelerBooksById(long kitapId)
        {
            IBooksDegerlendirmeService booksDegerlendirmeDal = InstanceFactory.GetInstance<IBooksDegerlendirmeService>().Service;
            var bookDgrlnLst = booksDegerlendirmeDal.GetList(kitapId);
            List<VM_BOOKS_DEGERLENDIRME> vmDegerlendirmeList = ObjectMapper.MapList(bookDgrlnLst, new List<VM_BOOKS_DEGERLENDIRME>());

            return vmDegerlendirmeList;
        }

        [HttpGet]
        [Route("GetCommenstBooksById")]
        public List<VM_BOOKS_COMMENT> GetCommenstBooksById(long kitapId)
        {
            IBooksCommentService booksCommentDal = InstanceFactory.GetInstance<IBooksCommentService>().Service;
            var bookCmmtLst = booksCommentDal.GetList(kitapId);
            List<VM_BOOKS_COMMENT> vmCmmteList = ObjectMapper.MapList(bookCmmtLst, new List<VM_BOOKS_COMMENT>());

            return vmCmmteList;
        }


        [HttpPost]
        [Route("TumKitaplar")]
        public List<VM_BOOKS> TumKitaplar(VM_ARAMA_INPUT arama)
        {
            List<Books> bookList = bookList = booksService.GetBooksList(); 
            if (!string.IsNullOrEmpty(arama.KITAP_ADI))
            {
                bookList = bookList.Where(p => p.Name.Contains(arama.KITAP_ADI!)).ToList();
            }

            if (arama.yazarIId.HasValue)
            {
                bookList = bookList.Where(p => p.YazarId == arama.yazarIId.Value).ToList();
            }

            if (arama.BitenKitaplar.HasValue)
            {
                bookList = bookList.Where(p => p.TAMAMLANDIMI == arama.BitenKitaplar.Value).ToList();
            }

            if (arama.DevamEdenKitaplar.HasValue)
            {
                bookList = bookList.Where(p => p.TAMAMLANDIMI == !arama.DevamEdenKitaplar.Value).ToList();
            }

            if (arama.YayinlananKitaplar.HasValue)
            {
                bookList = bookList.Where(p => p.YAYINDAMI == arama.YayinlananKitaplar.Value).ToList();
            }

            if (arama.FavoriKitaplar.HasValue)
            {
                bookList = bookList.Where(p => p.FavoriBooks.Any()).ToList();
            }
             
            var vmBookList = ObjectMapper.MapList(bookList, new List<VM_BOOKS>());

            foreach (var item in vmBookList)
            {
                var bookEntity = bookList.First(b => b.ID == item.ID);
                if (bookEntity == null) continue;

                item.Stars = booksService.CalculateMaxStar(bookEntity);

                item.iSTATISTIK = booksService.CalculateBookIstatistic(bookEntity);
            }

            return vmBookList;
        }
       
        private async Task<VM_BOOKS> ModelIlgiliDosyalariDoldur(VM_BOOKS input, List<IFormFile> files)
        {
            foreach (var item in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await item.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    // Ön kapak
                    if (!string.IsNullOrEmpty(input.ONKAPAKFOTO) && input.ONKAPAKFOTO == item.FileName)
                    {
                        input.ONKAPAKFOTO = Convert.ToBase64String(fileBytes);
                        input.ONKAPAKFOTOPATH = "";
                        // FTP'ye yükle
                        var uploadResult = await _ftpService.Upload(item);
                        if (uploadResult.IsSuccess)
                            input.ONKAPAKFOTOPATH = uploadResult.Result.FileName;
                        else
                            _logger.LogWarning("ONKAPAKFOTO yüklenemedi: {FileName}", item.FileName + " Hata : " + uploadResult.Message);
                        
                    }

                    // Arka kapak
                    if (!string.IsNullOrEmpty(input.ARKAKAPAKFOTO) && input.ARKAKAPAKFOTO == item.FileName)
                    {
                        input.ARKAKAPAKFOTO = Convert.ToBase64String(fileBytes);
                        input.ARKAKAPAKFOTOPATH = "";
                         var uploadResult = await _ftpService.Upload(item);
                        if (uploadResult.IsSuccess)
                            input.ARKAKAPAKFOTOPATH = uploadResult.Result.FileName;
                        else
                            _logger.LogWarning("ARKAKAPAKFOTO yüklenemedi: {FileName}", item.FileName + " Hata : " + uploadResult.Message);
                        
                    }

                    // KITAPSAYFAFOTO gerekirse buraya eklenebilir
                }
            }

            return input;
        }


        [HttpPost]
        [Route("PostSaveBook")]
        public async Task<ServiceResult<Books>> PostSaveBook([FromForm] VM_BOOKS_DETAIL VMbookDetay)
        {
            ServiceResult<Books> result = new ServiceResult<Books>(state: MessageResultState.SUCCESS);
            VM_BOOKS_DETAIL VMbook = new VM_BOOKS_DETAIL();

            var files = VMbookDetay.dosyalar;
            if (files?.Count != 0 && files != null)
            {
                VMbookDetay.BookModel = await ModelIlgiliDosyalariDoldur(VMbookDetay.BookModel, files);
            }
            VMbook = VMbookDetay;
            // ObjectMapper.Map(VMbookDetay, VMbook);

            var sonuc = _booksAddValidator.Validate(VMbook.BookModel);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }
                result.State = MessageResultState.WARNING;
                return result;
            }

            var book =   ObjectMapper.Map(VMbook.BookModel, new Books());
            var getBook = booksService.PostSaveBook(book);
            result.Result = getBook;
             
            return result;
        }



        [HttpPost]
        [Route("PostFavoriBookSave")]
        public ServiceResult<FavoriBooks> PostFavoriBookSave(FavoriBooks fav)
        {
            ServiceResult<FavoriBooks> result = new ServiceResult<FavoriBooks>(state: MessageResultState.SUCCESS);
            try
            {
                var getFavUserList = booksService.GetFavoriBooksByuserId(fav.UserId);
                var check = getFavUserList.Where(p => p.BookId == fav.BookId).ToList();
                if (check.Count > 0)
                {
                    result.Message = "Bu kitap zaten favorilerinizde mevcut.";
                    result.State = MessageResultState.WARNING;
                    return result;
                }
                var getFav = booksService.PostFavoriSaveBook(fav);
                result.Result = getFav;
            }
            catch (Exception ex )
            {
                result.State = MessageResultState.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UpdateBook")]
        public ServiceResult<Books> UpdateBook(Books book)
        {

            ServiceResult<Books> result = new ServiceResult<Books>(state: MessageResultState.SUCCESS);
            int sayfaCount = booksPagesService.GetPagesByBooks(book.ID)!.Count();
            //sayfaCount = 60; test içindi
            if (sayfaCount < 50)
            {
                result.Message = "Kitap en az 50 ve üzeri sayfadan fazla olmalıdır.";
                result.State = MessageResultState.ERROR;
            }
            else
            {
                book = booksService.UpdateBook(book);
                if (book != null && book.TAMAMLANDIMI)
                {
                    result.Message = "Kitap Tamamlandı. İlgili kitaba yönlendiriliyorsunuz..";
                    result.State = MessageResultState.SUCCESS;
                }
                else
                {
                    result.State = MessageResultState.WARNING;
                    result.Message = "Kitap Tamamlanamadı";

                }

            }

            result.Result = book;

            return result;
        }

        [HttpPost]
        [Route("CheckBook")]
        public ServiceResult<Books> CheckBook(Books book)
        {

            ServiceResult<Books> result = new ServiceResult<Books>(state: MessageResultState.SUCCESS);
            var bookPages = booksPagesService.GetPagesByBooks(book.ID);
            int sayfaCount = bookPages!.Count();

            var vmBooks = ObjectMapper.Map(book, new VM_BOOKS());

            var VM_BOOKS_PAGES = ObjectMapper.MapList(bookPages, new List<VM_BOOKS_PAGES>());
            vmBooks.BooksPageList = VM_BOOKS_PAGES;
             
            var sonuc2 = _checkBooksValidator.Validate(vmBooks);

            if (!sonuc2!.IsValid)
            {
                var uniqueErrors = new HashSet<string>();

                foreach (var item in sonuc2.Errors)
                {
                    if (uniqueErrors.Add(item.ErrorMessage))
                    {
                        result.Message += item.ErrorMessage + ",";
                    }
                }

                result.State = MessageResultState.WARNING;
                return result;
            }

            result.Result = book;
            return result;
        }

        [HttpPost]
        [Route("DeleteBook")]
        public void DeleteBook(Books book)
        {
            int kitapId = Convert.ToInt32(book.ID);
            booksService.DeleteBook(kitapId); 
        }

    }
}
