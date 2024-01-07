using FluentValidation;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class EmailValidator : AbstractValidator<Users>
    {
        public EmailValidator()
        {
           
            RuleFor(x => x.EMAIL).Empty().WithMessage("Mail adresi boş olamaz");
            RuleFor(x=>x.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x).Must(EmailVarmi).WithMessage("Mail adresi yok,kayıt yaptırınız.");
            RuleFor(x => x).Must(SifreKontrol).WithMessage("Mail adresi yok,kayıt yaptırınız.");
        }

        private bool EmailVarmi(Users user)
        {
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>();
            var sonuc = kisilerDal.GetAllQueryable(p => p.EMAIL == user.EMAIL).ToList();
            if(!sonuc.Any())
            {
                return true;
            }
            
            return false;
        }

        private bool SifreKontrol(Users user)
        {
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>();
            var sonuc = kisilerDal.GetAllQueryable(p => p.EMAIL == user.EMAIL).FirstOrDefault();
            if (sonuc != null)
            {
                if(sonuc.PASSWORD == user.PASSWORD)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return true;
            }
            
        }
    }

}
