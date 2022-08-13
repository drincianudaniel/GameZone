using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure
{
    public class GameZoneContext : DbContext
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
        public DbSet<User> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reply>().HasOne(u => u.User).WithMany(u=> u.Replies).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reply>().HasOne(u => u.Comment).WithMany(u=> u.Replies).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Comment>().HasOne<User>(s => s.User).WithMany(g => g.Comments).HasForeignKey(s => s.UserId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
