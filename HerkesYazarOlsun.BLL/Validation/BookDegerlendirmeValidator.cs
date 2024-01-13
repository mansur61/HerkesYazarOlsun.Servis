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
    public class BookDegerlendirmeValidator : AbstractValidator<VM_BOOKS_DEGERLENDIRME>
    {
        public BookDegerlendirmeValidator()
        {
           
           // RuleFor(x => x.EMAIL).Empty().WithMessage("Mail adresi boş olamaz"); portaldan js den kontrolü var 
            RuleFor(x=>x.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x).Must(EmailVarmi).WithMessage("Mail adresi yok,kayıt yaptırınız.");
           // RuleFor(x => x).Must(AyniKayitVarmi).WithMessage("Güncelleme Yapıldı");

        }

        private bool EmailVarmi(VM_BOOKS_DEGERLENDIRME  degerlendirme)
        {
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>();
            var sonuc = kisilerDal.GetAllQueryable(p => p.EMAIL == degerlendirme.EMAIL).ToList();
            if(sonuc.Any())
            {
                return true;
            }
            
            return false;
        }
        private bool AyniKayitVarmi(VM_BOOKS_DEGERLENDIRME degerlendirme)
        {
            IBooksDegerlendirmeDal yazarDal = InstanceFactory.GetInstance<IBooksDegerlendirmeDal>();
            var sonuc = yazarDal.GetList(p => p.LoginUserId == degerlendirme.LoginUserId && p.BookId == degerlendirme.BookId).ToList();
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
