using Microsoft.Extensions.Logging;
using VanGog.Storage;

namespace VanGog
{
    class ApplicationInitializer
    {
        private readonly ILogger<ApplicationInitializer> _logger;

        public ApplicationInitializer(ILogger<ApplicationInitializer> logger)
        {
            _logger = logger;
        }

        public void StartApplication(IServiceProvider serviceProvider)
        {
            MigrationsRunner.ApplyMigrations(_logger, serviceProvider);
        }
    }
}
