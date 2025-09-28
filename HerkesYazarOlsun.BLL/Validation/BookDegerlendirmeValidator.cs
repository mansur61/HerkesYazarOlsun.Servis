using FluentValidation;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BookDegerlendirmeValidator : AbstractValidator<VM_BOOKS_DEGERLENDIRME>
    {
        private readonly IUsersDal _usersDal; 

        public BookDegerlendirmeValidator(IUsersDal usersDal, IBooksDegerlendirmeDal booksDegerlendirmeDal)
        {
            _usersDal = usersDal; 


            RuleFor(x=>x.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x).Must(EmailVarmi).WithMessage("Mail adresi yok,kayıt yaptırınız."); 

        }

        private bool EmailVarmi(VM_BOOKS_DEGERLENDIRME  degerlendirme)
        {
            IUsersDal kisilerDal = _usersDal;
            var sonuc = kisilerDal.GetAllQueryable(p => p.EMAIL == degerlendirme.EMAIL).ToList();
            if(sonuc.Any())
            {
                return true;
            }
            
            return false;
        }
       

    }

}
