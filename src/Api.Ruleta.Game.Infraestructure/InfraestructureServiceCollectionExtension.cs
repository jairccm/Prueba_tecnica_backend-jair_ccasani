using Api.Ruleta.Game.Infraestructure.Data;
using Api.Ruleta.Game.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Ruleta.Game.Infraestructure
{
    public static class InfraestructureServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BdtestContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
           );

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRuletaGameRepository, RuletaGameRepository>();
            return services;
        }
    }
}
