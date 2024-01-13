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
    public class WriterFollowValidator : AbstractValidator<WriterFollow>
    {
        public WriterFollowValidator()
        {
           // RuleFor(x => x).Must(AyniKayitVarmi).WithMessage("");
        }

        private bool AyniKayitVarmi(WriterFollow user)
        {
            IWriterFollowDal yazarDal = InstanceFactory.GetInstance<IWriterFollowDal>();
            var sonuc = yazarDal.GetList(p => p.LoginUserId == user.LoginUserId && p.YazarId == user.YazarId).ToList();
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
