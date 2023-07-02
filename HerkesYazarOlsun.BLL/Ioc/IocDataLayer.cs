
using HerkesYazarOlsun.DataLayer.Abstract;
using HerkesYazarOlsun.DataLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace HerkesYazarOlsun.BLL.Ioc
{
    public static class IocDataLayer
    {
        public static void IoCDataAccessLayerRegister(this IServiceCollection service)
        {
           
            service.AddTransient<IKisilerDal, KisilerDal>();
            service.AddTransient<IBooksDal, BooksDal>();
            service.AddTransient<IBooksPagesDal, BooksPagesDal>();
        }
    }
}
