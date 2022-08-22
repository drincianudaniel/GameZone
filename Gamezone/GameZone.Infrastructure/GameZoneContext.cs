using GameZone.Domain.Models;
using GameZoneModels;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Infrastructure
{
    public class GameZoneContext : DbContext
    {
        public GameZoneContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Game> Games { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: entity config
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reply>().HasOne(x => x.Comment).WithMany(x => x.Replies).OnDelete(DeleteBehavior.Restrict);

            // TODO: many to many config
            modelBuilder.Entity<GameDeveloper>()
                .HasKey(gd => new { gd.DeveloperId, gd.GameId });

            modelBuilder.Entity<GameDeveloper>()
                .HasOne(x => x.Game)
                .WithMany(x => x.Developers)
                .HasForeignKey(x => x.GameId);

            modelBuilder.Entity<GameDeveloper>()
                .HasOne(x => x.Developer)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.DeveloperId);

            modelBuilder.Entity<Game>()
                .HasMany(p => p.Genres)
                .WithMany(p => p.Games)
                .UsingEntity(j => j.ToTable("GameGenres"));



            // Configure users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("95e85692-3721-4bf9-9966-edab69ff81d5"),
                FirstName = "First name 1",
                LastName = "Last name 1",
                Email = "user1@test.com"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("8caa7fcd-41ce-4252-8ec2-2fffde755780"),
                FirstName = "First name 2",
                LastName = "Last name 2",
                Email = "user2@test.com"
            });

            // Configure Games
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = Guid.Parse("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2"),
                Name = "Game 1",
            });



            // Configure comments
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = Guid.Parse("7bf0dc94-f67d-4ea9-b6f6-048eb66b7ac8"),
                Content = "Content 1",
                UserId = Guid.Parse("95e85692-3721-4bf9-9966-edab69ff81d5"),
                GameId = Guid.Parse("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2")
            });

            modelBuilder.Entity<Reply>().HasData(new Reply
            {
                Id = Guid.Parse("982d4b3a-0880-4984-9f23-a202e57c9eb5"),
                Content = "Reply content 1",
                CommentId = Guid.Parse("7bf0dc94-f67d-4ea9-b6f6-048eb66b7ac8"),
                UserId = Guid.Parse("8caa7fcd-41ce-4252-8ec2-2fffde755780")
            });

            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = Guid.Parse("bf089e47-fc78-4592-9a49-33330ff0ab2c"),
                Content = "Content 2",
                UserId = Guid.Parse("95e85692-3721-4bf9-9966-edab69ff81d5"),
                GameId = Guid.Parse("dfc8f3f8-9d1a-49b7-8c5a-cddbde8f0af2")
            });
        }
        
        /* 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reply>().HasOne(u => u.User).WithMany(u=> u.Replies).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reply>().HasOne(u => u.Comment).WithMany(u=> u.Replies).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>().HasOne<User>(s => s.User).WithMany(g => g.Comments).HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Game>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<User>().HasAlternateKey(x => x.Username);
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
