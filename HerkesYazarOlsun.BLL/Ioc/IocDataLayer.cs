
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace HerkesYazarOlsun.BLL.Ioc
{
    public static class IocDataLayer
    {
        public static void IoCDataAccessLayerRegister(this IServiceCollection service)
        {
           
            service.AddTransient<IUsersDal, UsersDal>();
            service.AddTransient<IFavYazarDal, FavYazarDal>();
            service.AddTransient<IFavorilerDal, FavorilerDal>();
            service.AddTransient<IBooksDal, BooksDal>();
            service.AddTransient<IBooksPagesDal, BooksPagesDal>();
        }
    }
}
