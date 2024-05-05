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
    public class BooksPagesAddValidator : AbstractValidator<VM_BOOKS_PAGES>
    {
        public BooksPagesAddValidator()
        {
            RuleFor(x => x.PageWrite).Empty().WithMessage("Kitap Sayfa Kısmı boş olamaz");
            RuleFor(x => x.PageWrite.Length > 1800).Empty().WithMessage("En fazla 1800 karakter girmelisiniz");            
           
        }

    }

}
