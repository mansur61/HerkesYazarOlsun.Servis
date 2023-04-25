using Microsoft.Extensions.DependencyInjection;


namespace HerkesYazarOlsun.BLL.Ioc
{
    public static class ServiceFactory
    {
        //interface yolluyorsunuz
        public static T Get<T>(this IServiceProvider serviceProvider)
        {
            T service = serviceProvider.GetService<T>();
            return service;
        }
    }
}
