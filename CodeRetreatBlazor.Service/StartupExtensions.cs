using Microsoft.Extensions.DependencyInjection;

namespace CodeRetreatBlazor.Service
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            return services;
        }
    }
}
