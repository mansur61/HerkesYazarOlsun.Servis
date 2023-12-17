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
    public class UsersValidator : AbstractValidator<Users>
    {
        public UsersValidator()
        {
            RuleFor(x => x).Must(BosOlmaDurumlariniKontrolEt).WithMessage("Kullanıcı Adı, Şifre veya Email alanları boş olamaz.");
            RuleFor(x => x.TELNO).Length(11).WithMessage("Telefon Numarası 11 haneli olmalıdır");
            RuleFor(x=>x.EMAIL).EmailAddress().WithMessage("Geçerli Mail adresi giriniz");
            RuleFor(x => x).Must(BaskaEmailVarmi).WithMessage("Aynı mail adresinden var");
            RuleFor(x => x).Must(BaskaTelNoVarmi).WithMessage("Aynı telefondan kayıtlı kullanıcı var");
        }

        private bool BosOlmaDurumlariniKontrolEt(Users user)
        {
            if (user.USERNAME == null)
            {
                return false;
            }
            if (user.PASSWORD == null)
            {
                return false;
            }
            if (user.EMAIL == null)
            {
                return false;
            }
            return true;
        }

        private bool BaskaEmailVarmi(Users user)
        {
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>();
            var sonuc = kisilerDal.GetAllQueryable(p => p.USERNAME == user.USERNAME).ToList();
            if (sonuc.Any() && sonuc.Count() > 1)
            {
                return false;
            }
            else{
                return true;
            }
        }
        private bool BaskaTelNoVarmi(Users user)
        {
            IUsersDal kisilerDal = InstanceFactory.GetInstance<IUsersDal>();
            var sonuc = kisilerDal.GetAllQueryable(p => p.TELNO == user.TELNO).ToList();
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
