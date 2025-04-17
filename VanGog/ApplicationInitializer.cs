using VanGog.Storage;

namespace VanGog
{
    /// <summary>
    /// класс - нициализатор приложения (для автоматического применения миграций при запуске)
    /// </summary>
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
