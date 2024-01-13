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
    public class WriterStarsValidator : AbstractValidator<WriterStars>
    {
        public WriterStarsValidator()
        {
            //RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("Güncelleme Yapıldı");
        }

        private bool BaskaTelNoVarmi(WriterStars star)
        {
            IWriterStarsDal yazarDal = InstanceFactory.GetInstance<IWriterStarsDal>();
            var sonuc = yazarDal.GetList(p => p.LoginUserId == star.LoginUserId && p.YazarId == star.YazarId).ToList();
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
