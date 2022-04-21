using Microsoft.Extensions.DependencyInjection;
using SmartPoles.Data.Repositories;
using SmartPoles.Domain.Interfaces.Repositories;

namespace SmartPoles.IoC
{
    public static class Repositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICondominiumRepository, CondominiumRepository>();
            services.AddTransient<IPoleRepository, PoleRepository>();

            return services;
        }
    }
}
