using FluentValidation;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksPagesAddValidator : AbstractValidator<VM_BOOKS_PAGES>
    {
        private const int pageLenght = 1800;
        public BooksPagesAddValidator()
        {
            RuleFor(x => x.PageWrite).NotEmpty().WithMessage("Kitap Sayfa Kısmı boş olamaz");
            //RuleFor(x => x.PageWrite.Length > pageLenght).NotEmpty().WithMessage("En fazla 1800 karakter girmelisiniz");            
           
        }

    }

}
