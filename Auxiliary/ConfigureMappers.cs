using TEMPLATE.CrossCutting.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE.CrossCutting
{
    public static class ConfigureMappers
    {
        public static void ConfigureDependenciesMapper(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cnf =>
            {
                //Adicione todos os mapeamentos de contratos               
                //cnf.AddProfile(new UsuarioEntitiesToContractMap());
            });

            var mapConfiguration = config.CreateMapper();
            serviceCollection.AddSingleton(mapConfiguration);
        }
    }
}