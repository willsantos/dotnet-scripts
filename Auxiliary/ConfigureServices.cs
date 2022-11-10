using TEMPLATE.Domain.Interfaces.Service;
using TEMPLATE.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE.CrossCutting
{
    public static class ConfigureServices
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            //Altere adicionando seus serviços
            //serviceCollection.AddScoped<INomeService, NomeService>();
        }
    }
}