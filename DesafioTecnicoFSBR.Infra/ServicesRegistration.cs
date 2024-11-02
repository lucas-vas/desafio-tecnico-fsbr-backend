using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using DesafioTecnicoFSBR.Domain.Interfaces.Services;
using DesafioTecnicoFSBR.Domain.Services.Brand;
using DesafioTecnicoFSBR.Domain.Services.Car;
using DesafioTecnicoFSBR.Infra.Configuration.User;
using DesafioTecnicoFSBR.Infra.Contexts;
using DesafioTecnicoFSBR.Infra.Integration.Uow;
using DesafioTecnicoFSBR.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTecnicoFSBR.Infra
{
    public static class ServicesRegistration
    {
        public static IServiceCollection ApplyInfraConfiguration(this IServiceCollection services, string connectionString)
        {
            services.ApplyDatabaseConfiguration(connectionString)
                    .ApplyDepedencyIngection();

            return services;
        }

        private static IServiceCollection ApplyDepedencyIngection(this IServiceCollection services)
        {
            services.AddDepedencyIngectionRepositories()
                    .AddDepedencyIngectionServices();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICurrentUser, CurrentUser>();
            
            return services;
        }

        private static IServiceCollection AddDepedencyIngectionRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            return services;
        }

        private static IServiceCollection AddDepedencyIngectionServices(this IServiceCollection services)
        {
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IBrandService, BrandService>();

            return services;
        }

        private static IServiceCollection ApplyDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>
            (
                options => options.UseSqlServer(connectionString)
            );

            return services;
        }
    }
}
