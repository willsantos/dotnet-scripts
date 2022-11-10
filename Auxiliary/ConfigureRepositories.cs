using TEMPLATE.Domain.Interfaces.Repository;
using TEMPLATE.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE.CrossCutting
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connectionString)
        {
            //Altere adicionando seus repositórios
            //serviceCollection.AddScoped<INomeRepository, NomeRepository>();

            //Altere caso mude o banco de dados
            serviceCollection.AddDbContext<ApiDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}