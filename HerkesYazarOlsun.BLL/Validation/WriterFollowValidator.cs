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
            //"İlgili Yazar Sadece 1 kez takip edilebilir/edilemez. İsteğiniz güncelleme olarak algılanmıştır ve uygulanmıştır. Takip isteğiniz geri alınmıştır"
            RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("");
        }

        private bool BaskaTelNoVarmi(WriterFollow user)
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
