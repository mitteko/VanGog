using Microsoft.EntityFrameworkCore;

namespace VanGog.Storage
{
    public class MigrationsRunner
    {
        public static void ApplyMigrations(VanGogDbContext dbContext)
        {
            try
            {
                // Проверяем, существует ли колонка CreatorId
                bool creatorIdExists = false;
                try
                {
                    // Пробуем выполнить запрос, который использует CreatorId
                    dbContext.Database.ExecuteSqlRaw("SELECT \"CreatorId\" FROM \"Events\" LIMIT 1");
                    creatorIdExists = true;
                }
                catch
                {
                    creatorIdExists = false;
                }

                // Если колонка не существует, добавляем её
                if (!creatorIdExists)
                {
                    dbContext.Database.ExecuteSqlRaw("ALTER TABLE \"Events\" ADD COLUMN \"CreatorId\" TEXT");
                }

                // Проверяем, существует ли колонка Participants
                bool participantsExists = false;
                try
                {
                    // Пробуем выполнить запрос, который использует Participants
                    dbContext.Database.ExecuteSqlRaw("SELECT \"Participants\" FROM \"Events\" LIMIT 1");
                    participantsExists = true;
                }
                catch
                {
                    participantsExists = false;
                }

                // Если колонка существует, удаляем её
                if (participantsExists)
                {
                    dbContext.Database.ExecuteSqlRaw("ALTER TABLE \"Events\" DROP COLUMN \"Participants\"");
                }

                // Применяем все миграции
                dbContext.Database.Migrate();
            }
            catch (Exception)
            {
                // Просто пробрасываем исключение дальше
                throw;
            }
        }
    }
}
