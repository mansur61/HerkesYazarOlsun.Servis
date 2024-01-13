using FluentValidation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
