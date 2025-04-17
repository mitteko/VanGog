using Microsoft.Extensions.Logging;
using VanGog.Storage;

namespace VanGog
{
    public class ApplicationInitializer
    {
        public void StartApplication()
        {
            using (var dbContext = new VanGogDbContext())
            {
                MigrationsRunner.ApplyMigrations(dbContext);
            }
        }
    }
}
