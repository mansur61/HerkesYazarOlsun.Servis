using FluentValidation;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class WriterFollowValidator : AbstractValidator<WriterFollow>
    {
        public WriterFollowValidator()
        {
           // RuleFor(x => x).Must(AyniKayitVarmi).WithMessage("");
        }

        
    }

}
