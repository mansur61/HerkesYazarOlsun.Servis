using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Enums;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;
using System.Drawing;
using System.Net;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class CheckBooksValidator : AbstractValidator<VM_BOOKS>
    {
        private IBooksPagesService _booksPagesService;
        private IBooksService _bookservice;

        private ICategoryService _categoryService;

        private const int pageLenght = 1800;
        private const int pageWordLenght = 200;
        private const int kitapSiirIseWordLenght = 50;


        public CheckBooksValidator()
        {
            var validationMessages = new List<string>();
            _booksPagesService = InstanceFactory.GetInstance<IBooksPagesService>();
            _bookservice = InstanceFactory.GetInstance<IBooksService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();

            RuleForEach(x => x.BooksPageList)
            .ChildRules(page =>
            {
                // Sayfa boş olamaz kontrolü
                page.RuleFor(x => x.PageWrite)
                    .NotEmpty()
                    .WithMessage("Kitap Sayfa Kısmı boş olamaz");

                // Sayfa minimum kelime kontrolü
                page.RuleFor(x => x.PageWrite)
                    .Must((parent, context) =>
                    {
                        var book = _bookservice.GetBooks(parent.BooksId);
                        int minWordCount = book.CategoriId == (int)BookCategory.Siir
                            ? kitapSiirIseWordLenght
                            : pageLenght;

                        int wordCount = context?.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length ?? 0;
                        return wordCount >= minWordCount;
                    })
                    .WithMessage((parent, context) =>
                    {
                        var book = _bookservice.GetBooks(parent.BooksId);
                        int minWordCount = book.CategoriId == (int)BookCategory.Siir
                            ? kitapSiirIseWordLenght
                            : pageLenght;

                        return $"Kitabın ilgili Sayfası ({parent.ID}), en az {minWordCount} kelime içermelidir.";
                    });
            });

            // Kitabın en az 50 sayfa olması gerektiğini kontrol ediyoruz
            RuleFor(x => x.ID ?? 0)
                .Must(HasMinimumPageCount)
                .WithMessage("Kitap en az 50 ve üzeri sayfadan fazla olmalıdır");

            // Tüm sayfaların en az `minWordCount` kelime içermesi gerektiğini kontrol ediyoruz
            RuleFor(x => x.ID)
            .Must(bookId =>
            {
                Books book = _bookservice.GetBooks(bookId ?? 0);
                int minWordCount = 0;
                if (book.CategoriId == (int)BookCategory.Siir)
                {
                    minWordCount = kitapSiirIseWordLenght;
                }
                else
                {
                    minWordCount = pageLenght;
                }

                var insufficientPageIndex = GetInsufficientPageIndex(bookId ?? 0, minWordCount);
                return insufficientPageIndex == null;
            })
            .WithMessage(x =>
            {
                int minWordCount = 0;
                if (x.CategoriId == (int)BookCategory.Siir)
                {
                    minWordCount = kitapSiirIseWordLenght;
                }
                else
                {
                    minWordCount = pageLenght;
                }

                var insufficientPageIndex = GetInsufficientPageIndex(x.ID ?? 0, minWordCount);
                return insufficientPageIndex != null
                    ? $"Yetersiz karakter sayısına sahip ilgili sayfalar: {string.Join(", ", insufficientPageIndex)}"
                    : string.Empty;
            });

        }

        private bool HasMinimumPageCount(long bookId)
        {
            int pageCount = _booksPagesService.GetPagesByBooks(bookId).Count();
            return pageCount >= 50;
        }

        private List<int>? GetInsufficientPageIndex(long bookId, int minWordCount)
        {
            //Books book = _bookservice.GetBooks(bookId);           

            // Belirtilen bookId'ye göre sayfaları alıyoruz
            var pages = _booksPagesService.GetPagesByBooks(bookId);
            List<int> currentPage = new List<int>();
            // Yetersiz kelime sayısına sahip ilk sayfa indeksini buluyoruz
            for (int i = 0; i < pages.Count; i++)
            {
                int wordCount = pages[i].PageWrite.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

                // Eğer kelime sayısı yetersizse sayfa indeksini döndür
                if (wordCount <= minWordCount)
                {
                    var currentPageId = Convert.ToInt64(pages[i].ID.ToString());
                    currentPage.Add((int)currentPageId);
                    //return i; // Yetersiz kelime sayısına sahip sayfa indeksi
                }
            }

            // Tüm sayfalar yeterli kelime sayısına sahipse null döndür
            return currentPage.Count > 0 ? currentPage : null;
        }

    }
}
