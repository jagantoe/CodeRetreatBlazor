using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodeRetreatBlazor.DataAccess
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureDataAccess(this IServiceCollection services)
        {
            return services.AddDbContext<ChallengeContext>();
        }
    }
}
