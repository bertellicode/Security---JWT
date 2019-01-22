using Microsoft.Extensions.DependencyInjection;
using Security.Infra.CrossCutting.IoC;

namespace Security.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
