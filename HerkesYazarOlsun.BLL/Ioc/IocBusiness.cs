

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

            service.AddScoped<IFtpService, FtpWebService>();
            
        }

        public static T GetService<T>(IServiceProvider serviceProvider)
        {
            T service = serviceProvider.GetService<T>();
            return service;
        }
    }
}
