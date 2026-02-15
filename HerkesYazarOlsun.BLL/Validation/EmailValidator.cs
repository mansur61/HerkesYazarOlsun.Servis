using FluentValidation;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class EmailValidator : AbstractValidator<Users>
    {
        private IUsersDal _kisilerDal;
        public EmailValidator(IUsersDal kisilerDal)
        {
            _kisilerDal = kisilerDal;
            //RuleFor(x => x.EMAIL).Empty().WithMessage("Mail adresi boş olamaz");
            RuleFor(x=>x.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x).Must(EmailVarmi).WithMessage("Mail adresi yok,kayıt yaptırınız.");
        }

        private bool EmailVarmi(Users user)
        { 
            var sonuc = _kisilerDal.GetAllQueryableNoTracking(p => p.EMAIL == user.EMAIL).ToList();
            if(!sonuc.Any())
            {
                return false;
            }
            
            return true;
        }
  }

}
