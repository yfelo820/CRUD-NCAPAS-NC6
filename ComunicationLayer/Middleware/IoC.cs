using BusinesLogic.Interfaces;
using BusinesLogic.Services;

namespace ComunicationLayer.Middleware
{
    public static class IoC
    {

        public static IServiceCollection AddDependency(this IServiceCollection services)
        {            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEntityDB, EntityDB>();

            return services;
        }
    }
}
