using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Validation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Utils;
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
            IBooksStarsDal yazarDal = InstanceFactory.GetInstance<IBooksStarsDal>();

           BooksStarsValidator validationRules = new BooksStarsValidator();
            var sonuc = validationRules.Validate(star);

            if (!sonuc!.IsValid)
            {
                //result.State = MessageResultState.ERROR;
                foreach (var item in sonuc.Errors)
                {
                    result.Message += item.ErrorMessage + ",";
                }

                try
                {
                    yazarDal.Update(star);
                    result.State = MessageResultState.WARNING;
                }
                catch (Exception)
                {
                    result.Message = "";
                    result.State = MessageResultState.ERROR;
                }

                return result;
            }


            star = yazarDal.Add(star);

            result.Result = star;
            return result;
        }


        [HttpGet]
        [Route("GetMaxStarBooksById")]
        public VM_Stars GetMaxStarBooksById(long id)
        {
            return booksService.GetMaxStarBooksById(id);
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

    }
}
