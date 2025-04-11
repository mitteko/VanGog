using Microsoft.EntityFrameworkCore;
using VanGog.Storage.Core.Entities;


namespace VanGog.Storage
{
    public class VanGogDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public VanGogDbContext() { }
        public VanGogDbContext(DbContextOptions<VanGogDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=vangog-db;User ID=postgres;Password=902692A2006UN951967;");
            }
        }
    }
}
