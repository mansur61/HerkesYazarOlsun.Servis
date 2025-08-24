using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model;
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
        private ICategoryService _categoryService;
        private IBooksPagesService booksPagesService;
        private readonly ILogger<BooksController> _logger;
        private IFtpService _ftpService;
        public BooksController(IBooksService _booksService, IBooksPagesService _booksPagesService, ICategoryService categoryService,
            IFtpService ftpService, ILogger<BooksController> logger,
            IUserAccessor userAccessor, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            : base(userAccessor, unitOfWork, httpContextAccessor)
        {
            booksService = _booksService;
            booksPagesService = _booksPagesService;
            _categoryService = categoryService;
            _ftpService = ftpService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetBooks")]
        public Books GetBooks(long id)
        {

            var getBook = booksService.GetBooks(id);
            //var vmBook = ObjectMapper.Map(getBook, new VM_BOOKS());
            //vmBook.iSTATISTIK = GetISTATISTIKLERBooksById(id);
            return getBook;
        }

        [HttpGet]
        [Route("GetBooksList")]
        public List<VM_BOOKS> GetBooksList()
        {
            var getBookList = booksService.GetBooksList();
            var lst = new List<VM_BOOKS_COMMENT>();

            var vmBookList = ObjectMapper.MapList(getBookList, new List<VM_BOOKS>());
            try
            {
                foreach (var item in vmBookList)
                {
                    item.Stars = GetMaxStarBooksById(item.ID ?? 0);
                    item.iSTATISTIK = GetISTATISTIKLERBooksById(item.ID ?? 0);
                    var comments = GetCommenstBooksById(item.ID ?? 0);
                    item.bookComments = comments;
                    // Assign the comment count to the book
                    item.CommentCount = comments.Count;
                    var categoryModel = _categoryService.GetCategoryById(item.ID ?? 0);
                    item.CategoryName = categoryModel != null ? categoryModel.Name : "";
                }
            }
            catch (Exception e)
            {
                var _ = e.Message;
                return vmBookList;
            }

            return vmBookList;
        }

        [HttpPost]
        [Route("PostBooksStars")]
        public ServiceResult<BooksStars> PostBooksStars(BooksStars star)
        {
            ServiceResult<BooksStars> result = new ServiceResult<BooksStars>(state: MessageResultState.SUCCESS);
            IBooksStarsDal bookStarDal = InstanceFactory.GetInstance<IBooksStarsDal>();

            BooksStarsValidator validationRules = new BooksStarsValidator();
            var sonuc = validationRules.Validate(star);

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
                star = bookStarDal.Add(star);
                //using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                //{
                //    var mevcutKayit = ctx.BooksStars.Where(p => p.LoginUserId == star.LoginUserId && p.BookaId == star.BookaId).FirstOrDefault();
                //    if (mevcutKayit == null)
                //    {
                //        star = bookStarDal.Add(star);
                //    }
                //    else
                //    {
                //        mevcutKayit!.StarPuani = star.StarPuani;

                //        ctx.BooksStars.Update(mevcutKayit);
                //        ctx.SaveChanges();
                //    } 
                //}

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
            IBooksDegerlendirmeDal booksDegerlendirmeDal = InstanceFactory.GetInstance<IBooksDegerlendirmeDal>();

            BookDegerlendirmeValidator validationRules = new BookDegerlendirmeValidator();
            var sonuc = validationRules.Validate(degerlendirme);

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
                booksDegerlendirmeDal.Add(booksDegerlendirme);
                //using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                //{
                //    var mevcutKayit = ctx.BooksDegerlendirme.Where(p => p.LoginUserId == degerlendirme.LoginUserId && p.BookId == degerlendirme.BookId).FirstOrDefault();
                //    booksDegerlendirmeDal.Add(booksDegerlendirme);
                //    if (mevcutKayit == null)
                //    {
                //        booksDegerlendirmeDal.Add(booksDegerlendirme);
                //    }
                //    else
                //    {
                //        mevcutKayit!.StarPuani = degerlendirme.StarPuani;
                //        ctx.BooksDegerlendirme.Update(mevcutKayit);
                //        ctx.SaveChanges();
                //    }

                //}

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
            IBooksCommentDal booksCommentDal = InstanceFactory.GetInstance<IBooksCommentDal>();

            BooksCommentValidator validationRules = new BooksCommentValidator();
            var sonuc = validationRules.Validate(mesajlar);

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
                booksCommentDal.Ekle(booksDegerlendirme, MAIL ?? mesajlar.EMAIL ?? "");
                //using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                //{
                //    var mevcutKayit = ctx.BooksComment.Where(p => p.LoginUserId == mesajlar.LoginUserId && p.BookId == mesajlar.BookId).FirstOrDefault();
                //    booksCommentDal.Ekle(booksDegerlendirme, MAIL ?? mesajlar.EMAIL ?? "");
                //    if (mevcutKayit == null)
                //    {
                //        booksCommentDal.Ekle(booksDegerlendirme, MAIL);
                //    }
                //    else
                //    {
                //        ctx.BooksComment.Update(mevcutKayit);
                //        ctx.SaveChanges();
                //    }

                //}

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


        [HttpGet]
        [Route("GetMaxStarBooksById")]
        public VM_Stars GetMaxStarBooksById(long id)
        {
            return booksService.GetMaxStarBooksById(id);
        }

        [HttpGet]
        [Route("GetISTATISTIKLERBooksById")]
        public VM_BOOK_ISTATISTIKLER GetISTATISTIKLERBooksById(long id)
        {
            return booksService.GetISTATISTIKLERBooksById(id);
        }

        [HttpGet]
        [Route("GetDegerlendirmelerBooksById")]
        public List<VM_BOOKS_DEGERLENDIRME> GetDegerlendirmelerBooksById(long kitapId)
        {
            IBooksDegerlendirmeDal booksDegerlendirmeDal = InstanceFactory.GetInstance<IBooksDegerlendirmeDal>();
            var bookDgrlnLst = booksDegerlendirmeDal.GetList(p => p.BookId == kitapId).ToList();
            List<VM_BOOKS_DEGERLENDIRME> vmDegerlendirmeList = ObjectMapper.MapList(bookDgrlnLst, new List<VM_BOOKS_DEGERLENDIRME>());

            return vmDegerlendirmeList;
        }

        [HttpGet]
        [Route("GetCommenstBooksById")]
        public List<VM_BOOKS_COMMENT> GetCommenstBooksById(long kitapId)
        {
            IBooksCommentDal booksCommentDal = InstanceFactory.GetInstance<IBooksCommentDal>();
            var bookCmmtLst = booksCommentDal.GetAllQueryable(p => p.BookId == kitapId).ToList();
            List<VM_BOOKS_COMMENT> vmCmmteList = ObjectMapper.MapList(bookCmmtLst, new List<VM_BOOKS_COMMENT>());

            return vmCmmteList;
        }


        [HttpPost]
        [Route("TumKitaplar")]
        public List<VM_BOOKS> TumKitaplar(VM_ARAMA_INPUT arama)
        {
            List<Books> bookList = bookList = booksService.GetBooksList(); //new List < Books >();
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

            var vmBookList = ObjectMapper.MapList(bookList, new List<VM_BOOKS>());
            foreach (var item in vmBookList)
            {
                item.Stars = GetMaxStarBooksById(item.ID ?? 0);
                var categoryModel = _categoryService.GetCategoryById(item.ID ?? 0);
                item.CategoryName = categoryModel != null ? categoryModel.Name : "";
                item.iSTATISTIK = GetISTATISTIKLERBooksById(item.ID ?? 0);
            }

            return vmBookList;
        }
        private async Task<ServiceResponse<VM_File_Result>> Upload(IFormFile file)
        {
            var sonuc = new ServiceResponse<VM_File_Result>(null) { IsSuccess = true };

            try
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    var bytes = ms.ToArray();
                    var fileName = file.FileName;
                    string extension = fileName.Split('.').Last();

                    var newFileName = Guid.NewGuid() + "." + extension;
                    string filePath = _ftpService.SaveDosyaByte(newFileName, bytes);

                    var uploadResult = new VM_File_Result
                    {
                        IsSuccess = true,
                        FileName = filePath
                    };

                    sonuc = new ServiceResponse<VM_File_Result>(uploadResult)
                    {
                        IsSuccess = true,
                        Message = "Dosya FTP'ye yüklendi"
                    };
                }
            }
            catch (Exception ex)
            {
                sonuc = new ServiceResponse<VM_File_Result>(new VM_File_Result
                {
                    IsSuccess = false,
                    FileName = "Dosya yükleme başarısız."
                })
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

                _logger.LogError(ex, "Upload sırasında hata oluştu. File: {@File}", file.FileName);
            }

            return sonuc;
        }

        // FTP AYARLANINCA AKTİF HALE GETİR
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
                        /*var uploadResult = await Upload(item);
                        if (uploadResult.IsSuccess)
                            input.ONKAPAKFOTOPATH = uploadResult.Result.FileName;
                        else
                            _logger.LogWarning("ONKAPAKFOTO yüklenemedi: {FileName}", item.FileName);*/
                    }

                    // Arka kapak
                    if (!string.IsNullOrEmpty(input.ARKAKAPAKFOTO) && input.ARKAKAPAKFOTO == item.FileName)
                    {
                        input.ARKAKAPAKFOTO = Convert.ToBase64String(fileBytes);
                        input.ARKAKAPAKFOTOPATH = "";
                        /*var uploadResult = await Upload(item);
                        if (uploadResult.IsSuccess)
                            input.ARKAKAPAKFOTOPATH = uploadResult.Result.FileName;
                        else
                            _logger.LogWarning("ARKAKAPAKFOTO yüklenemedi: {FileName}", item.FileName);*/
                    }

                    // KITAPSAYFAFOTO gerekirse buraya eklenebilir
                }
            }

            return input;
        }



        [HttpPost]
        [Route("PostSaveBook")]
        public async Task<ServiceResult<Books>> PostSaveBook([FromForm] VM_BOOKS VMbook)
        {
            ServiceResult<Books> result = new ServiceResult<Books>(state: MessageResultState.SUCCESS);
            VM_BOOKS vmBooks = new VM_BOOKS();
            
            vmBooks = VMbook;

            var files = VMbook.dosyalar;
            if (files?.Count != 0 && files != null)
            {
                VMbook = await ModelIlgiliDosyalariDoldur(VMbook, files);
            }

            vmBooks.BookModel = VMbook.BookModel;
            vmBooks.BookModel.ARKAKAPAKFOTOPATH = VMbook.ARKAKAPAKFOTOPATH;
            vmBooks.BookModel.ONKAPAKFOTOPATH = VMbook.ONKAPAKFOTOPATH;

            vmBooks.BookModel.ARKAKAPAKFOTO = VMbook.ARKAKAPAKFOTO;
            vmBooks.BookModel.ONKAPAKFOTO = VMbook.ONKAPAKFOTO;
            vmBooks.YazarId = vmBooks.BookModel.YazarId;

            BooksAddValidator validationRules = new BooksAddValidator();
            var sonuc = validationRules.Validate(vmBooks);

            if (!sonuc!.IsValid)
            {
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }
                result.State = MessageResultState.WARNING;
                return result;
            }


            var getBook = booksService.PostSaveBook(VMbook.BookModel);
            result.Result = getBook;
            return result;
        }



        [HttpPost]
        [Route("PostFavoriBookSave")]
        public ServiceResult<FavoriBooks> PostFavoriBookSave(FavoriBooks fav)
        {
            ServiceResult<FavoriBooks> result = new ServiceResult<FavoriBooks>(state: MessageResultState.SUCCESS);
            var getFav = booksService.PostFavoriSaveBook(fav);
            result.Result = getFav;
            return result;
        }

        [HttpPost]
        [Route("UpdateBook")]
        public ServiceResult<Books> UpdateBook(Books book)
        {

            ServiceResult<Books> result = new ServiceResult<Books>(state: MessageResultState.SUCCESS);
            int sayfaCount = booksPagesService.GetPagesByBooks(book.ID)!.Count();
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

            CheckBooksValidator validationRules = new CheckBooksValidator();
            var sonuc2 = validationRules.Validate(vmBooks);

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
            //booksService.DeleteBook(kitapId);

            using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
            {
                var kitap = ctx.Books.Where(p => p.ID == kitapId).FirstOrDefault();
                if (kitap != null)
                {
                    ctx.Books.Remove(kitap); // Kitabı sil
                    ctx.SaveChanges(); // Değişiklikleri kaydet
                }
            }
        }

    }
}
