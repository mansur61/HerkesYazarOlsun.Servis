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
