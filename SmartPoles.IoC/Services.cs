using Microsoft.Extensions.DependencyInjection;
using SmartPoles.CrossCutting.Services;
using SmartPoles.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
