using System;
using Microsoft.Extensions.DependencyInjection;
using Security.Application.AutoMapper;

namespace Security.Api.Configurations
{
    public static class AutoMapperConfiguration
    {

        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapperSetup();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }

    }
}
