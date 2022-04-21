using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartPoles.Application.Requests.Commands;

namespace SmartPoles.IoC
{
    public static class Mediator
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AuthenticateRequest));
            return services;
        }
    }
}
