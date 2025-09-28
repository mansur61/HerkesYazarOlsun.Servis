
using HerkesYazarOlsun.BLL.Concrete;
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Concrete;
using HerkesYazarOlsun.DataLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace HerkesYazarOlsun.BLL.Ioc
{
    public static class IocDataLayer
    {
        public static void IoCDataAccessLayerRegister(this IServiceCollection service)
        {
           
            service.AddScoped<IUsersDal, UsersDal>();
            service.AddScoped<ICategoryDal, CategoryDal>();
            service.AddScoped<IFavYazarDal, FavYazarDal>();
            service.AddScoped<IKartlarDal, KartlarDal>();
            service.AddScoped<IOdemeDal, OdemeDal>();
            service.AddScoped<IYayinAyarlariDal, YayinAyarlariDal>();
            
            service.AddScoped<IAccountLoginDal, AccountLoginDal>();
            service.AddScoped<IBildirimlerDal, BildirimlerDal>();
            service.AddScoped<IUsersDetailsDal, UsersDetailsDal>();
            service.AddScoped<IProfilDal, ProfilDal>();
            service.AddScoped<IAyarlarDal, AyarlarDal>();
            service.AddScoped<ICarouselDuyuruDal, CarouselDuyuruDal>();
            service.AddScoped<ITaleplerDal, TaleplerDal>();
            service.AddScoped<IOdemeSponsorlariDal, OdemeSponsorlariDal>();
            service.AddScoped<ISponsorlarDal, SponsorlarDal>();
            service.AddScoped<IBooksDegerlendirmeDal, BooksDegerlendirmeDal>();
            service.AddScoped<IBooksCommentDal, BooksCommentDal>();
            service.AddScoped<IWriterStarsDal, WriterStarsDal>();
            service.AddScoped<IBooksStarsDal, BooksStarsDal>();
            service.AddScoped<IWriterFollowDal, WriterFollowDal>();
            service.AddScoped<IFavBookDal, FavBookDal>();
            service.AddScoped<IBooksDal, BooksDal>();
            service.AddScoped<IBooksPagesDal, BooksPagesDal>();
        }
    }
}
