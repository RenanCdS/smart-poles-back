using Microsoft.Extensions.DependencyInjection;
using SmartPoles.Application.Services;
using SmartPoles.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoles.IoC
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITokenService, TokenService>();

            return services;
        }
    }
}
