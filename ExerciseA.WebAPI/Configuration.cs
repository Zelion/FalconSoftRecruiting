using AutoMapper;
using ExerciseA.Domain.Respositories;
using ExerciseA.Domain.Services;
using ExerciseA.Implementation2.Repositories;
using ExerciseA.WebAPI.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseA.WebAPI.Services
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
