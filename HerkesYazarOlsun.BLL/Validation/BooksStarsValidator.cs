using FluentValidation;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksStarsValidator : AbstractValidator<BooksStars>
    {
        public BooksStarsValidator()
        {
            //RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("Güncelleme Yapıldı"); 'Güncelleme Yapıldı' şekilde validtör kullanma
        } 
    }

}
