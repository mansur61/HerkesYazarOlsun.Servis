using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Context;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HerkesYazarOlsun.Servis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseApiController
    {
        private IBooksService booksService;
       
        public BooksController(IBooksService _booksService, IUserAccessor userAccessor) :base(userAccessor)
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
        public List<VM_BOOKS> GetBooksList()
        {
            var getBookList = booksService.GetBooksList();

            var vmBookList = ObjectMapper.MapList(getBookList, new List<VM_BOOKS>());
            foreach (var item in vmBookList)
            {
                item.Stars = GetMaxStarBooksById(item.ID);
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
                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    var mevcutKayit = ctx.BooksStars.Where(p => p.LoginUserId == star.LoginUserId && p.BookaId == star.BookaId).FirstOrDefault();
                    if (mevcutKayit == null)
                    {
                        star = bookStarDal.Add(star);
                    }
                    else
                    {
                        mevcutKayit!.StarPuani = star.StarPuani;

                        ctx.BooksStars.Update(mevcutKayit);
                        ctx.SaveChanges();
                    }

                   
                }

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
                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    var mevcutKayit = ctx.BooksDegerlendirme.Where(p => p.LoginUserId == degerlendirme.LoginUserId && p.BookId == degerlendirme.BookId).FirstOrDefault();
                    if(mevcutKayit == null)
                    {
                        booksDegerlendirmeDal.Add(booksDegerlendirme);
                    }
                    else
                    {
                        mevcutKayit!.StarPuani = degerlendirme.StarPuani;
                        ctx.BooksDegerlendirme.Update(mevcutKayit);
                        ctx.SaveChanges();
                    }
                   
                }

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
                using (HerkesYazaOlsunContext ctx = new HerkesYazaOlsunContext())
                {
                    var mevcutKayit = ctx.BooksComment.Where(p => p.LoginUserId == mesajlar.LoginUserId && p.BookId == mesajlar.BookId).FirstOrDefault();
                    if (mevcutKayit == null)
                    {
                        booksCommentDal.Ekle(booksDegerlendirme,MAIL);
                    }
                    else
                    {
                        ctx.BooksComment.Update(mevcutKayit);
                        ctx.SaveChanges();
                    }

                }

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
            List < Books > bookList = bookList = booksService.GetBooksList(); //new List < Books >();
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

            var vmBookList = ObjectMapper.MapList(bookList,new  List<VM_BOOKS>());
            foreach (var item in vmBookList)
            {
                item.Stars = GetMaxStarBooksById(item.ID);
            }

            return vmBookList;
        }

        [HttpPost]
        [Route("PostSaveBook")]
        public Books PostSaveBook(Books book)
        {
            var getBook = booksService.PostSaveBook(book);

            return getBook;
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
        public Books UpdateBook(Books book)
        {
            var getBook = booksService.UpdateBook(book);

            return getBook;
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
