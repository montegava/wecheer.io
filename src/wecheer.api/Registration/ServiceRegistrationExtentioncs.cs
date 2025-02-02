using Wecheer.Core.Services;

namespace Wecheer.Api.Registration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IStorageService>(new StorageService());
            return services;
        }
    }
}
