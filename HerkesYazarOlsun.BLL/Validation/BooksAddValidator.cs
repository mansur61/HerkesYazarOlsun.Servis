using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BusinessLayer.Factory;
using HerkesYazarOlsun.Model.Entity;
using HerkesYazarOlsun.Model.Enums;
using HerkesYazarOlsun.Model.Utils;
using HerkesYazarOlsun.Model.ViewModel;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class BooksAddValidator : AbstractValidator<VM_BOOKS>
    {
        private IBooksService _bookservice;
        public BooksAddValidator()
        {
            _bookservice = InstanceFactory.GetInstance<IBooksService>();

            RuleFor(x => x.ARKAKAPAKFOTO).Empty().WithMessage("Arka Kapak Fotoğrafı boş olamaz");
            RuleFor(x => x.ONKAPAKFOTO).Empty().WithMessage("Ön Kapak Fotoğrafı boş olamaz");

            RuleFor(x => x.ONSOZ).Empty().WithMessage("Önsöz boş olamaz");
            RuleFor(x => x.Name).Empty().WithMessage("Kitap Adı boş olamaz");
            RuleFor(x => x.YazarId).Empty().WithMessage("Yazar Bilgisi Alınamadı");
            //RuleFor(x => x.YazarId == 0).Empty().WithMessage("Yazar Bilgisi Alınamadı");

            RuleFor(x => x.CategoriId).Empty().WithMessage("Kitap  kategorisi boş olamaz");
             
        }

    }

}
