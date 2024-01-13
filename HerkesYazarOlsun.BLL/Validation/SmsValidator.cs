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
    public class SmsValidator : AbstractValidator<Users>
    {
        public SmsValidator()
        {

            RuleFor(x => x.TELNO).Length(11).WithMessage("Telefon Numarası 11 haneli olmalıdır");
        }

    }

}
