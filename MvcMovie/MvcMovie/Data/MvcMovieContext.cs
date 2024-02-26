using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options){}
        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Artist> Artist { get; set; } = default!;
        public DbSet<Studio> Studio { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToTable("Movie").HasKey(m => m.MovieId);
            modelBuilder.Entity<User>().ToTable("User").HasKey(u => u.UserId);
            modelBuilder.Entity<Artist>().ToTable("Artist").HasKey(a => a.ArtistId);
            modelBuilder.Entity<Studio>().ToTable("Studio").HasKey(s => s.StudioId);

            modelBuilder.Entity<Movie>()
                .HasOne<Studio>()
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.StudioId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Artists)
                .WithMany(m => m.Movies);
            
            // modelBuilder.Entity<Artist>()
            //     .HasMany<Movie>()
            //     .WithMany(a => a.Artists);

            modelBuilder.Entity<Studio>()
                .HasMany(s => s.Movies)
                .WithOne(s => s.Studio);
        }
    }
}
