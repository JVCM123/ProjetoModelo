using ProjetoModelo.Domain.Interfaces.Services;
using ProjetoModelo.Services.AppServices;

namespace ProjetoModeloApi.IoC.Modules
{
    public class ServiceModule
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<IValidacaoService, ValidacaoService>();
        }
    }
}