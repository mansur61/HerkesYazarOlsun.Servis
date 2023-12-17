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
    public class BooksStarsValidator : AbstractValidator<BooksStars>
    {
        public BooksStarsValidator()
        {
            RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("Güncelleme Yapıldı");
        }

        private bool BaskaTelNoVarmi(BooksStars star)
        {
            IBooksStarsDal yazarDal = InstanceFactory.GetInstance<IBooksStarsDal>();
            var sonuc = yazarDal.GetList(p => p.LoginUserId == star.LoginUserId && p.BookaId == star.BookaId).ToList();
            if (sonuc.Any())
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
