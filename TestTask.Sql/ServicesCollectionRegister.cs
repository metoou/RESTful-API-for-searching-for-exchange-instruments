using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TestTask.Sql
{
    public static class ServicesCollectionRegister
    {
        public static void AddAllDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DatabaseContext>(x
                => x.UseNpgsql(configuration.GetConnectionString("TestTaskConnectionString")));
        }
    }
}
