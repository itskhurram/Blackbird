using Blackbird.Domain.Interfaces;
using Blackbird.Infrastructure.Logging.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.Infrastructure.IOC.Container {
    public class DependencyContainer {
        public static void RegisterServices(IServiceCollection services) {
            ServicesRegistration(services);
            RepositoryRegistration(services);
            ApploggerRegistration(services);
        }
        private static void ServicesRegistration(IServiceCollection services) {
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<ILeadService, LeadService>();
            //services.AddTransient<IJWTRefreshTokenService, JWTRefreshTokenService>();
        }
        private static void RepositoryRegistration(IServiceCollection services) {
            //services.AddTransient<IBaseRepository, BaseRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<ILeadRepository, LeadRepository>();
            //services.AddTransient<IJWTRefreshTokenRepository, JWTRefreshTokenRepository>();
            //services.AddScoped<IMemoryCacheProvider, MemoryCacheProvider>();
        }

        private static void ApploggerRegistration(IServiceCollection services) {
            services.AddSingleton<IApplogger, Applogger>();
        }
    }
}
