using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class CheckBooksValidator : AbstractValidator<VM_BOOKS>
    {
        private IBooksPagesService _booksPagesService;
        private const int pageLenght = 1800;
        private const int pageWordLenght = 200;
        public CheckBooksValidator()
        {

            _booksPagesService = InstanceFactory.GetInstance<IBooksPagesService>();

            RuleForEach(x => x.BooksPageList)
            .ChildRules(page =>
            {
                page.RuleFor(x => x.PageWrite)
                    .NotEmpty().WithMessage("Kitap Sayfa Kısmı boş olamaz");

                page.RuleFor(x => x.PageWrite)
                    .Must(content => content.Length <= pageLenght)
                    .WithMessage($"Kitabın ilgili Sayfa içeriği en fazla {pageLenght} karakter olabilir");

                page.RuleFor(x => x.PageWrite)
                    .Must(content => content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length >= pageLenght)
                    .WithMessage($"Kitabın ilgili Sayfası en az {pageWordLenght} kelime içermelidir");
            });
            // Kitabın en az 50 sayfa olması gerektiğini kontrol ediyoruz
            RuleFor(x => x.ID)
                .Must(HasMinimumPageCount)
                .WithMessage("Kitap en az 50 ve üzeri sayfadan fazla olmalıdır");

            // Tüm sayfaların en az `minWordCount` kelime içermesi gerektiğini kontrol ediyoruz
            RuleFor(x => x.ID)
            .Must(bookId =>
            {
                var insufficientPageIndex = GetInsufficientPageIndex(bookId, pageLenght);
                return insufficientPageIndex == null;
            })
            .WithMessage(x =>
            {
                var insufficientPageIndex = GetInsufficientPageIndex(x.ID, pageLenght);
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
            // Belirtilen bookId'ye göre sayfaları alıyoruz
            var pages = _booksPagesService.GetPagesByBooks(bookId);
            List<int> currentPage = new List<int>();
            // Yetersiz kelime sayısına sahip ilk sayfa indeksini buluyoruz
            for (int i = 0; i < pages.Count; i++)
            {
                int wordCount = pages[i].PageWrite.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

                // Eğer kelime sayısı yetersizse sayfa indeksini döndür
                if (wordCount < minWordCount)
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
