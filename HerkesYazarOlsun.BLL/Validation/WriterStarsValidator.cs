using FluentValidation;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class WriterStarsValidator : AbstractValidator<WriterStars>
    {
        public WriterStarsValidator()
        {
            //RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("Güncelleme Yapıldı");
        }

        
    }

}
