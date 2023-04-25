using HerkesYazarOlsun.BLL.Ioc;
using Ninject;

namespace HerkesYazarOlsun.BusinessLayer.Factory
{
    public class InstanceFactory
    {
        public static IServiceProvider Provider { get; set; }
        private static IKernel _kernel = null;

        public static T GetInstance<T>()
        {
            return Provider.Get<T>();
        }

        //public static IKernel GetKernel()
        //{
        //    if (_kernel == null)
        //    {
        //        _kernel = new StandardKernel(new MainModule());
        //    }
        //    return _kernel;
        //}
    }
}
