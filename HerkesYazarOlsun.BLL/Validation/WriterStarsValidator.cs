using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class WriterStarsValidator : AbstractValidator<WriterStars>
    {
        private IWriterStarsService wrtStarsService;
        public WriterStarsValidator(IWriterStarsService wrtStarsService)
        { 
           // this.wrtStarsService = wrtStarsService; 
           // RuleFor(x => x)
           //.Must(NotDuplicateStar)
           //.WithMessage("İlgili Kullanıcıya Daha önce Yıldız Verdiniz."); 
        }
        private bool NotDuplicateStar(WriterStars model)
        {
            if (!model.LoginUserId.HasValue)
            {
                return false;
            }

            return !wrtStarsService.GetWriterStarsByuserId(model.LoginUserId.Value).Any(x =>
                x.LoginUserId == model.LoginUserId &&
                x.YazarId == model.YazarId &&
                x.ID != model.ID // Güncellemede aynı kaydı hariç tut
            );
        }

    }

}
