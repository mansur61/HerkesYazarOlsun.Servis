

using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Accessor;
using HerkesYazarOlsun.BLL.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace HerkesYazarOlsun.BLL.Ioc
{
    /// <summary>
    /// The ioc business
    /// </summary>
    public static class IocBusiness
    {
        /// <summary>
        /// Ioes the c business logic layer register.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void IoCBusinessLogicLayerRegister(this IServiceCollection service)
        {
            service.AddScoped<IUsersService, UsersBll>();
            service.AddScoped<ICategoryService, CategoryBll>();
            service.AddScoped<IUserAccessor, HttpUserAccessor>();
            service.AddScoped<IHttpContextAccessor, HttpContextAccessor>();         
            service.AddScoped<IBooksService, BooksBll>();
            service.AddScoped<IBooksPagesService, BooksPagesBll>();
            service.AddScoped<ICarouselService, CarouselBll>();
            service.AddScoped<IKartlarService, KartlarBll>();
            service.AddScoped<IOdemeService, OdemeBll>();
            service.AddScoped<IOdemeSponsorlariService, OdemeSponsorlariBll>();
            service.AddScoped<IProfilService, ProfilBll>();
            service.AddScoped<IAyarlarService, AyarlarBll>();
            service.AddScoped<IYayinAyarlariService, YayinAyarlariBll>();
            service.AddScoped<IUsersDetailsService, UsersDetailsBll>();         
            service.AddScoped<IFtpService, FtpWebService>();
            service.AddScoped<IBildirimlerService, BildirimlerBll>();
            service.AddScoped<ISponsorlarService, SponsorlarBll>();
            service.AddScoped<ITaleplerService, TaleplerBll>();
            service.AddScoped<IAccountLoginService, AccountLoginBll>();
            service.AddScoped<IWriterFollowService, WriterFollowBll>();
            service.AddScoped<IFavoriYazarlarService, FavYazarBll>();
            service.AddScoped<IWriterStarsService, WriterStarsBll>();
            service.AddScoped<IBooksStarsService, BooksStarsBll>();
            service.AddScoped<IBooksDegerlendirmeService, BooksDegerlendirmeBll>();
            service.AddScoped<IBooksCommentService, BooksCommentBl>();
            service.AddScoped<ICategoryYayinAyarlariService, CategoryYayinAyarlariBll>();

            


        }

        public static T GetService<T>(IServiceProvider serviceProvider)
        {
            T service = serviceProvider.GetService<T>();
            return service;
        }
    }
}
