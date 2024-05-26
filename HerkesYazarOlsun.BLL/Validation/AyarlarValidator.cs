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
           // RuleFor(x => x.User.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
        }

        private bool AyniLoginUserNoVarmi(VM_AYARLAR ayr)
        {
            IAyarlarDal ayrDal = InstanceFactory.GetInstance<IAyarlarDal>();
            var sonuc = ayrDal.GetAllQueryable(p => p.LoginUserId == ayr.LoginUserId).ToList();
            if (sonuc.Any() && sonuc.Count() > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}
