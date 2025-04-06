using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VanGog.Storage
{
    public class MigrationsRunner
    {
        public static async Task ApplyMigrations(ILogger logger, IServiceProvider serviceProvider)
        {
            logger.LogInformation($"UpdateDatabase: starting...");
            try
            {
                using (var serviceScope = serviceProvider.CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetRequiredService<VanGogDbContext>();
                    await dbContext.Database.MigrateAsync();
                }
                
                logger.LogInformation($"UpdateDatabase: successfully done");
                await Task.FromResult(true);
            }
            catch (Exception exception)
            {
                logger.LogCritical(exception, $"UpdateDatabase: Migration failed");
                throw;
            }
        }
    }
}
