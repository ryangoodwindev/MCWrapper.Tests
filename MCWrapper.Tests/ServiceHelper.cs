using MCWrapper.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace MCWrapper.Tests
{
    public static class ServiceHelper
    {
        private static readonly IServiceCollection Services = new ServiceCollection();
        private static readonly ServiceProvider ServiceProvider;

        static ServiceHelper()
        {
            Services.AddMultiChainCoreServices();

            if (ServiceProvider == null)
                ServiceProvider = Services.BuildServiceProvider();
        }

        public static T GetService<T>() => ServiceProvider.GetService<T>();
    }
}
