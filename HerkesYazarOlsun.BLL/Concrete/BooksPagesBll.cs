using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.Extensions.Logging;

namespace HerkesYazarOlsun.BLL.Concrete
{
    public class BooksPagesBll : IBooksPagesService
    {
        private readonly IBooksPagesDal _booksPagesDal;
        private IUserAccessor _userAccessor;
        private IFtpService _ftpService;
        private readonly ILogger<BooksPagesBll> _logger;
        public BooksPagesBll(IBooksPagesDal BooksPagesDal, IUserAccessor userAccessor, IFtpService ftpService, ILogger<BooksPagesBll> logger)
        {
            _booksPagesDal = BooksPagesDal;
            _userAccessor = userAccessor;
            _ftpService = ftpService;
            _logger = logger;
        }

        public BooksPages? GetBooksPages(long id)
        {
            return _booksPagesDal.GetAllQueryableNoTracking(p => p.ID == id).FirstOrDefault();

        }

        public List<BooksPages> GetPagesByBooks(long bookID)
        {
            return _booksPagesDal.GetAllQueryableNoTracking(p => p.BookId == bookID).ToList();

        }
        public List<BooksPages> GetBooksPagesList()
        {
            return _booksPagesDal.GetAll();
        }



        public async Task ModelIlgiliKitapSayfaDosyaSil(string dosyaYolu)
        {
            await _ftpService.DeleteDosyaByte(dosyaYolu);
        }

        public async Task<VM_BOOKS_PAGES> ModelIlgiliKitapSayfaDosyalariDoldur(VM_BOOKS_PAGES? inputPage)
        {
            foreach (var item in inputPage.PageFotoDosyalar)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await item.CopyToAsync(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    // FTP'ye yükle
                    var uploadResult = await _ftpService.Upload(item, isProfile: false, isBookPage: true);
                    if (uploadResult.IsSuccess)
                        inputPage.PageFoto = uploadResult.Result.FileName;
                    else
                        _logger.LogWarning("kitap sayfa resim yüklenemedi: {FileName}",
                            item.FileName + " Hata : " + uploadResult.Message);

                }
            }

            return inputPage;
        }

        public BooksPages PostSaveBooksPages(BooksPages book)
        {

            return _booksPagesDal.Ekle(book, _userAccessor.MAIL);
        }

        public BooksPages? PostUpdateBooksPages(VM_BOOKS_PAGES bookPageSayfa)
        {
            var guncellenecekSayfa = GetBooksPages(bookPageSayfa.ID);
            if (guncellenecekSayfa != null)
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
