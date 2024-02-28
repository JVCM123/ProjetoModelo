using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProjetoModeloApi.IoC.Modules;

namespace ProjetoModeloApi.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            ServiceModule.InjectDependencies(services);
            return services;
        }
    }
}
