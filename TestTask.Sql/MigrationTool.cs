using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TestTask.Sql
{
    public sealed class MigrationTool
    {
        private readonly IServiceProvider _rootServiceProvider;
        private readonly ILogger<MigrationTool> _logger;

        public static void Execute(IServiceProvider serviceProvider) => new MigrationTool(serviceProvider).Migrate();

        public MigrationTool(IServiceProvider rootServiceProvider)
        {
            _rootServiceProvider = rootServiceProvider;
            _logger = rootServiceProvider.GetRequiredService<ILogger<MigrationTool>>();
        }

        public void Migrate()
        {
            _logger.LogInformation("Creating scope...");
            using (var scope = _rootServiceProvider.CreateScope())
            {
                var dbContextCollection = ResolveDbContextCollection(scope.ServiceProvider);
                foreach (var dbContext in dbContextCollection)
                {
                    _logger.LogInformation($"Migrating DbContext '{dbContext.GetType()}'...");
                    dbContext.Database.Migrate();
                    _logger.LogInformation($"Migrate for DbContext '{dbContext.GetType()}' is complete");
                }
                _logger.LogInformation("Releasing scope");
            }

            _logger.LogInformation("Migrations are complete");
        }
        private static IEnumerable<DbContext> ResolveDbContextCollection(IServiceProvider serviceProvider)
        {
            yield return serviceProvider.GetRequiredService<DatabaseContext>();
        }
    }
}
