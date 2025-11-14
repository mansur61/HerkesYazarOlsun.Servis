using FluentValidation;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksCommentValidator : AbstractValidator<VM_BOOKS_COMMENT>
    {
        private IUsersDal _kisilerDal;
        public BooksCommentValidator(IUsersDal kisilerDal)
        {
            _kisilerDal = kisilerDal;

            RuleFor(x=>x.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x).Must(EmailVarmi).WithMessage("Mail adresi yok,kayıt yaptırınız."); 

        }

        private bool EmailVarmi(VM_BOOKS_COMMENT mesaj)
        { 
            var sonuc = _kisilerDal.GetAllQueryableNoTracking(p => p.EMAIL == mesaj.EMAIL).ToList();
            if(sonuc.Any())
            {
                return true;
            }
            
            return false;
        }
        
    }

}
