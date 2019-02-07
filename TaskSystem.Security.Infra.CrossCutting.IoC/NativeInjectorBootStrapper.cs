using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Security.Application.Interfaces;
using Security.Application.Services;
using Security.Domain.Core.Interfaces;
using Security.Domain.Core.Notifications;
using Security.Domain.Users.Interfaces.Repositories;
using Security.Domain.Users.Interfaces.Services;
using Security.Domain.Users.Services;
using Security.Infra.CrossCutting.JWT.Configurations;
using Security.Infra.CrossCutting.JWT.Interfaces;
using Security.Infra.CrossCutting.JWT.Models;
using Security.Infra.Data.Context;
using Security.Infra.Data.Repositories;
using Security.Infra.Data.UoW;

namespace Security.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Application
            services.AddScoped<IUserAppService, UserAppService>();

            // Domain - Core
            services.AddScoped<INotificationHandler, NotificationHandler>();

            // Services
            services.AddScoped<IUserService, UserService>();

            // Infra - Data
            services.AddScoped<SecurityContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Infra - JWT
            services.AddScoped<ICredentialsConfiguration, CredentialsConfiguration>();
            services.AddScoped<ITokenConfiguration, TokenConfiguration>();
            services.AddScoped<IUserProvider, UserProvider>();

            //Web
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }
    }
}
