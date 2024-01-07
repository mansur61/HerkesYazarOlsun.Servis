
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Concrete.EntityFramework;
using HerkesYazarOlsun.Model.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace HerkesYazarOlsun.BLL.Ioc
{
    public static class IocDataLayer
    {
        public static void IoCDataAccessLayerRegister(this IServiceCollection service)
        {
           
            service.AddTransient<IUsersDal, UsersDal>();
            service.AddTransient<IFavYazarDal, FavYazarDal>();
            service.AddTransient<IKartlarDal, KartlarDal>();
            service.AddTransient<IOdemeDal, OdemeDal>();

            service.AddTransient<IBildirimlerDal, BildirimlerDal>();
            service.AddTransient<IUsersDetailsDal, UsersDetailsDal>();
            service.AddTransient<IProfilDal, ProfilDal>();
            service.AddTransient<IAyarlarDal, AyarlarDal>();

            service.AddTransient<IOdemeSponsorlariDal, OdemeSponsorlariDal>();
            service.AddTransient<ISponsorlarDal, SponsorlarDal>();
            service.AddTransient<IBooksDegerlendirmeDal, BooksDegerlendirmeDal>();
            service.AddTransient<IBooksCommentDal, BooksCommentDal>();
            service.AddTransient<IWriterStarsDal, WriterStarsDal>();
            service.AddTransient<IBooksStarsDal, BooksStarsDal>();
            service.AddTransient<IWriterFollowDal, WriterFollowDal>();
            service.AddTransient<IFavBookDal, FavBookDal>();
            service.AddTransient<IBooksDal, BooksDal>();
            service.AddTransient<IBooksPagesDal, BooksPagesDal>();
        }
    }
}
