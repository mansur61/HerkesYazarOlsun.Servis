using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Enums;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksAddValidator : AbstractValidator<VM_BOOKS>
    {
        private const int pageLenght = 1800;
        private const int pageWordLenght = 200;
        private const int kitapSiirIseWordLenght = 50;

        private IBooksService _bookservice;
        public BooksAddValidator()
        {
            _bookservice = InstanceFactory.GetInstance<IBooksService>();

            RuleFor(x => x.ARKAKAPAKFOTO).Empty().WithMessage("Arka Kapak Fotoğrafı boş olamaz");
            RuleFor(x => x.ONKAPAKFOTO).Empty().WithMessage("Ön Kapak Fotoğrafı boş olamaz");

            RuleFor(x => x.ONSOZ).Empty().WithMessage("Önsöz boş olamaz");
            RuleFor(x => x.Name).Empty().WithMessage("Kitap Adı boş olamaz");
            RuleFor(x => x.YazarId).Empty().WithMessage("Yazar Bilgisi Alınamadı"); 

            RuleFor(x => x.CategoriId).Empty().WithMessage("Kitap  kategorisi boş olamaz");

            RuleForEach(x => x.BooksPageList)
            .ChildRules(page =>
            {
                page.RuleFor(x => x.PageWrite)
                    .NotEmpty().WithMessage("Kitap Sayfa Kısmı boş olamaz");

              
                page.RuleFor(x => x.PageWrite)
                   .Must((parent, context) =>
                   {
                       Books book = _bookservice.GetBooks(parent.BooksId);
                       int minWordCount = book.CategoriId == (int)BookCategory.Siir
                           ? kitapSiirIseWordLenght
                           : pageLenght;

                       return context?.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length >= minWordCount;
                   })
                   .WithMessage(context =>
                   {

                       Books book = _bookservice.GetBooks(context.BooksId);
                       int minWordCount = book.CategoriId == (int)BookCategory.Siir
                           ? kitapSiirIseWordLenght
                           : pageLenght;

                       return $"Kitabın ilgili Sayfası ({context.ID}.),  en az {minWordCount} kelime içermelidir";
                   });

            });

        }

    }

}
