using GameZone.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure
{
    public class GameZoneContext : IdentityDbContext<User, Role, Guid>
    {
        public GameZoneContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reply> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Role>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
            });

            modelBuilder.Entity<Reply>().HasOne(u => u.User).WithMany(u => u.Replies).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reply>().HasOne(u => u.Comment).WithMany(u => u.Replies).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Comment>().HasOne<User>(s => s.User).WithMany(g => g.Comments).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditableEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
                else
                {
                    Entry((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedAt).IsModified = false;
                }

                ((AuditableEntity)entityEntry.Entity).ModifiedAt = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
