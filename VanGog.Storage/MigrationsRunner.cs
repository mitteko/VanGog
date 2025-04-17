using Microsoft.EntityFrameworkCore;

namespace VanGog.Storage
{
    /// <summary>
    /// Класс для применения миграций к базе данных
    /// </summary>
    public class MigrationsRunner
    {
        public static void ApplyMigrations(VanGogDbContext dbContext)
        {
            try
            {
                // проверяем, существует ли колонка CreatorId
                bool creatorIdExists = false;
                try
                {
                    // запрос, который использует CreatorId
                    dbContext.Database.ExecuteSqlRaw("SELECT \"CreatorId\" FROM \"Events\" LIMIT 1");
                    creatorIdExists = true;
                }
                catch
                {
                    creatorIdExists = false;
                }

                // если колонка не существует, добавляем её
                if (!creatorIdExists)
                {
                    dbContext.Database.ExecuteSqlRaw("ALTER TABLE \"Events\" ADD COLUMN \"CreatorId\" TEXT");
                }

                // проверяем, существует ли колонка Participants
                bool participantsExists = false;
                try
                {
                    // запрос, который использует Participants
                    dbContext.Database.ExecuteSqlRaw("SELECT \"Participants\" FROM \"Events\" LIMIT 1");
                    participantsExists = true;
                }
                catch
                {
                    participantsExists = false;
                }

                // если колонка существует, удаляем её
                if (participantsExists)
                {
                    dbContext.Database.ExecuteSqlRaw("ALTER TABLE \"Events\" DROP COLUMN \"Participants\"");
                }

                dbContext.Database.Migrate();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
