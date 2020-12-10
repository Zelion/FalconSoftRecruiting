using AutoMapper;
using ExerciseA.API.Mappings;
using ExerciseA.Domain.Respositories;
using ExerciseA.Domain.Services;
using ExerciseA.Domain.UnitsOfWork;
using ExerciseA.Implementation.Repositories;
using ExerciseA.Implementation.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ExerciseA.API.Services
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            // Services
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();

            // Repositories
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            // Units Of Work
            services.AddTransient<IOrderUnitOfWork, OrderUnitOfWork>();

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
