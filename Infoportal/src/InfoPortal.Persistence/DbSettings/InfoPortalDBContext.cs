using InfoPortal.Domains.Entities;
using InfoPortal.Persistence.DbMaps;
using Microsoft.EntityFrameworkCore;

namespace InfoPortal.Persistence.DbSettings
{
    public class InfoPortalDBContext : DbContext
    {
        public DbSet<NewsDb> News { get; set; } = null!;
        public DbSet<TagDb> Tags { get; set; } = null!;

        public InfoPortalDBContext(DbContextOptions<InfoPortalDBContext> options) : base(options)
        {
            // Database.EnsureCreated(); //для создания дб
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsMap());
            modelBuilder.ApplyConfiguration(new TagsMap());
        }

    }
}
