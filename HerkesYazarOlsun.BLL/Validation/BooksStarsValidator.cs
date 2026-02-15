using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksStarsValidator : AbstractValidator<BooksStars>
    {
        private IBooksStarsService booksStarsService;
        public BooksStarsValidator(IBooksStarsService booksStarsService)
        {
            this.booksStarsService = booksStarsService;
            //RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("Güncelleme Yapıldı"); 'Güncelleme Yapıldı' şekilde validtör kullanma
            RuleFor(x => x)
           .Must(NotDuplicateStar)
           .WithMessage("Aynı kullanıcı bu kitabı daha önce puanlamış.");
        }

        private bool NotDuplicateStar(BooksStars model)
        {
            return !booksStarsService.GetBooksStarsByuserId(model.LoginUserId).Any(x =>
                x.LoginUserId == model.LoginUserId &&
                x.BookId == model.BookId &&
                x.ID != model.ID // Güncellemede aynı kaydı hariç tut
            );
        }
    }

}
