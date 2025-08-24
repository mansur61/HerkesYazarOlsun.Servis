using FluentValidation;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksPagesAddValidator : AbstractValidator<VM_BOOKS_PAGES>
    {
        public BooksPagesAddValidator()
        {
            RuleFor(x => x.PageWrite).NotEmpty().WithMessage("Kitap Sayfa Kısmı boş olamaz");
            RuleFor(x => x.PageWrite.Length > 1800).NotEmpty().WithMessage("En fazla 1800 karakter girmelisiniz");            
           
        }

    }

}
