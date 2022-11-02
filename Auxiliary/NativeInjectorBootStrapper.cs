﻿using TEMPLATE.CrossCutting;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterAppDependencies(this IServiceCollection services)
        {
            ConfigureServices.ConfigureDependenciesService(services);
            ConfigureMappers.ConfigureDependenciesMapper(services);
        }

        public static void RegisterAppDependenciesContext(this IServiceCollection services, string connectionString)
        {
            ConfigureRepository.ConfigureDependenciesRepository(services, connectionString);
        }
    }
}