
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using LinqKit;
using Microsoft.AspNetCore.Mvc;

namespace HerkesYazarOlsun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AramaController : ControllerBase
    {
        private IBooksService booksService;

        public AramaController(IBooksService _booksService)
        {
            booksService = _booksService;
        }

        [HttpPost]
        [Route("TumAramalar")]
        public VM_ARAMA_SONUC TumAramalar(VM_ARAMA_INPUT arama)
        {
            IBooksDal bookDal = InstanceFactory.GetInstance<IBooksDal>().Service;
            IUsersDal userDal = InstanceFactory.GetInstance<IUsersDal>().Service;
            var bookList =  bookDal.GetAll();

            if (arama.kategoriId.HasValue)
            {
                bookList = bookList.Where(p=>p.CategoriId == arama.kategoriId.Value).ToList();
            }
            if (arama.tarihCeck.HasValue)
            {
                if (arama.tarihCeck.Value == 1)
                {
                    bookList = bookList.Where(p => p.CREATE_AT?.Year == DateTime.Now.Year).ToList();
                }
                else
                {
                    bookList = bookList.Where(p => p.CREATE_AT?.Year < DateTime.Now.Year).ToList();
                }
                
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
                bookList = bookList.Where(p => p.TAMAMLANDIMI == arama.DevamEdenKitaplar.Value).ToList();
            }

            if (arama.YayinlananKitaplar.HasValue)
            {
                bookList = bookList.Where(p => p.TAMAMLANDIMI == arama.YayinlananKitaplar.Value).ToList();
            }

            if (!string.IsNullOrEmpty(arama.YAZAR_ADI))
            {
                List<long> yazarIdler = new List<long>();
                List<Books> kitaplar = new List<Books>();
                var kullanicilar =  userDal.GetAllQueryable(p => p.NAME.Contains(arama.YAZAR_ADI)).ToList();
                foreach (var item in kullanicilar)
                {
                    yazarIdler.Add(item.ID);
                }
                foreach (var item in yazarIdler)
                {
                    bookList = bookList.Where(p=>p.YazarId == item).ToList();
                    foreach (var book in bookList)
                    {
                        kitaplar.Add(book);
                    }
                    
                }
                bookList = kitaplar;

            }
            if (!string.IsNullOrEmpty(arama.KITAP_ADI))
            {
                bookList = bookList.Where(p => p.Name.Contains(arama.KITAP_ADI)).ToList();
            }

            if (arama.siralama.HasValue)
            {
                if(arama.siralama.Value == 1)
                {
                    bookList = bookList.OrderByDescending(p=>p.ID).ToList();
                }
                else
                {
                    bookList = bookList.ToList();
                }
               
            }

            VM_ARAMA_SONUC sonuc = new VM_ARAMA_SONUC();
            sonuc.vmBook = new VM_BOOKS(); 
            sonuc.vmBook.BooksList = bookList;

            var vmBookList = ObjectMapper.MapList(bookList, new List<VM_BOOKS>());
            foreach (var item in vmBookList)
            {
                item.Stars = booksService.GetMaxStarBooksById(item.ID ?? 0);
            }
            sonuc.vmBook.VMBooksList = new List<VM_BOOKS>();
            sonuc.vmBook.VMBooksList = vmBookList;
            return sonuc;
        }

    }
}