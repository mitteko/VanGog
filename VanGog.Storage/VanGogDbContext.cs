using Microsoft.EntityFrameworkCore;
using VanGog.Storage.Core.Entities;


namespace VanGog.Storage
{
    public class VanGogDbContext(DbContextOptions<VanGogDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }
    }
}
