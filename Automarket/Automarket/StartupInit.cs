using Automarket.DAL.Interfaces;
using Automarket.DAL.Repositories;
using Automarket.Service.Implementations;
using Automarket.Service.Interfaces;

namespace Automarket
{
    public static class StartupInit
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
        }
    }
}
