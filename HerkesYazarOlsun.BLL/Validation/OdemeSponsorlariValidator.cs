using FluentValidation;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class OdemeSponsorlariValidator : AbstractValidator<VM_ODEME_SPONSORLARI>
    {
        public OdemeSponsorlariValidator()
        {          
            
            RuleFor(x=>x.Mail).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x.Tel).Length(11).WithMessage("Telefon Numarası 11 haneli olmalıdır");

        }

      
    }

}
