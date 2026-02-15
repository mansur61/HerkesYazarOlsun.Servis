using HerkesYazarOlsun.BLL.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace HerkesYazarOlsun.BusinessLayer.Factory
{
    public class ScopedService<T> : IDisposable where T : class
    {
        private readonly IServiceScope _scope;
        public T Service { get; }

        public ScopedService(IServiceProvider provider)
        {
            _scope = provider.CreateScope();
            Service = _scope.ServiceProvider.GetRequiredService<T>();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
 
    public static class InstanceFactory
    {
        public static IServiceProvider Provider { get; set; }

        /// <summary>
        /// Scoped servisi al ve güvenli şekilde kullan
        /// </summary>
        public static ScopedService<T> GetInstance<T>() where T : class
        {
            return new ScopedService<T>(Provider);
        }
    }
}
