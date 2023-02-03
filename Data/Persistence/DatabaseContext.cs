using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Unit>(entity => {
                entity.HasIndex(e => e.ProductId).IsUnique();
            });

            builder.Entity<Area>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            base.OnModelCreating(builder);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
