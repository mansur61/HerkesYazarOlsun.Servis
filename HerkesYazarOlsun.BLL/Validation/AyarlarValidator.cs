using FluentValidation;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class AyarlarValidator : AbstractValidator<VM_AYARLAR>
    {
        public AyarlarValidator()
        {
            //RuleFor(x => x.User.EMAIL).Empty().EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x.User.EMAIL)
            .Empty()
            .When(x => string.IsNullOrEmpty(x.User.EMAIL), ApplyConditionTo.CurrentValidator)
            .WithMessage("Geçerli Mail adresi giriniz")
            .EmailAddress()
            .When(x => !string.IsNullOrEmpty(x.User.EMAIL), ApplyConditionTo.CurrentValidator)
            .WithMessage("Geçerli Mail adresi giriniz");
        }
 
    }

}
