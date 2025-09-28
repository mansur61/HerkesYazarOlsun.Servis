using FluentValidation;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class SmsValidator : AbstractValidator<Users>
    {
        public SmsValidator()
        {

            RuleFor(x => x.TELNO).Length(11).WithMessage("Telefon Numarası 11 haneli olmalıdır");
        }

    }

}
