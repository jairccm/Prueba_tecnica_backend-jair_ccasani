using Api.Ruleta.Game.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Ruleta.Game.Application
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IRuletaGameService, RuletaGameService>();
            return services;
        }
    }
}
