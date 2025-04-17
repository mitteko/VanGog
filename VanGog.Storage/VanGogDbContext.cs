using Microsoft.EntityFrameworkCore;
using VanGog.Storage.Core.Entities;

namespace VanGog.Storage
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class VanGogDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public VanGogDbContext() { }
        public VanGogDbContext(DbContextOptions<VanGogDbContext> options) : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Host=ep-young-butterfly-a42fdodo-pooler.us-east-1.aws.neon.tech;Database=vangog;Username=vangog_owner;Password=npg_2HSMiq3GIFgn;SSL Mode=Require";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().ToTable("Events", "public");
        }

    }
}
