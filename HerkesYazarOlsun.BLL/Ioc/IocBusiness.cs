

using HerkesYazarOlsun.BLL.Abstract;
using HerkesYazarOlsun.BLL.Concrete;
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
            service.AddTransient<IUsersService, UsersBll>();
            service.AddTransient<IBooksService, BooksBll>();
            service.AddTransient< IBooksPagesService, BooksPagesBll>();
        }

        public static T GetService<T>(IServiceProvider serviceProvider)
        {
            T service = serviceProvider.GetService<T>();
            return service;
        }
    }
}
