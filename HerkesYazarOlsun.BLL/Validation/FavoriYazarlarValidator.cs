using FluentValidation;
using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.Model.Entity;

namespace HerkesYazarOlsun.BLL.Validation
{
    public class FavoriYazarlarValidator : AbstractValidator<FavoriYazarlar>
    {
        private IFavoriYazarlarService favYazarService;
        public FavoriYazarlarValidator(IFavoriYazarlarService favYazarService)
        {
            this.favYazarService = favYazarService;
             RuleFor(x => x)
           .Must(NotDuplicateStar)
           .WithMessage("Aynı kullanıcı yazarı daha önce puanlamış.");
        }

        private bool NotDuplicateStar(FavoriYazarlar model)
        {
            return !favYazarService.GetFavoriYazarlarByuserId(model.LoginUserId ?? 0).Any(x =>
                x.LoginUserId == model.LoginUserId &&
                x.YazarId == model.YazarId &&
                x.ID != model.ID // Güncellemede aynı kaydı hariç tut
            );
        }
    }

}
