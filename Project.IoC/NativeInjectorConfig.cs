using Microsoft.Extensions.DependencyInjection;
using Project.Business.Concrete;
using Project.Business.Contracts;
using Project.Domain.Contracts.Repositories;
using Project.Repository.Repositories;

namespace Project.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IKyberRepository, KyberRepository>();
            services.AddScoped<IKyberBusiness, KyberBusiness>();
        }
    }
}
