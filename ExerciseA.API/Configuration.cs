using AutoMapper;
using ExerciseA.API.Mappings;
using ExerciseA.Domain.Respositories;
using ExerciseA.Domain.Services;
using ExerciseA.Implementation.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseA.API.Services
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IOrderService, OrderService>();

            // Repositories
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }).CreateMapper());

            return services;
        }
    }
}
