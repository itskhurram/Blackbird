using Blackbird.Application.Interfaces;
using Blackbird.Application.Services;
using Blackbird.Domain.Interfaces;
using Blackbird.Domain.Interfaces.Base;
using Blackbird.Infrastructure.Caching.MemoryCache;
using Blackbird.Infrastructure.Logging.Logger;
using Blackbird.Infrastructure.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blackbird.Infrastructure.IOC.Container {
    public class DependencyContainer {
        public static void RegisterServices(IServiceCollection services) {
            ServicesRegistration(services);
            RepositoryRegistration(services);
            ApploggerRegistration(services);
        }
        private static void ServicesRegistration(IServiceCollection services) {
            services.AddTransient<IAccountTypeService, AccountTypeService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IJWTRefreshTokenService, JWTRefreshTokenService>();
        }
        private static void RepositoryRegistration(IServiceCollection services) {
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IAccountTypeRepository, AccountTypeRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            //services.AddTransient<IJWTRefreshTokenRepository, JWTRefreshTokenRepository>();
            services.AddScoped<IMemoryCacheProvider, MemoryCacheProvider>();
        }

        private static void ApploggerRegistration(IServiceCollection services) {
            services.AddSingleton<IApplogger, Applogger>();
        }
    }
}
