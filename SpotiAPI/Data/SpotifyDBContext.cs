using Microsoft.EntityFrameworkCore;
using Spotify_DataLayer.Models;

namespace SpotiAPI.Data
{
    public class SpotifyDBContext:DbContext
    {
        public SpotifyDBContext(DbContextOptions options):base(options) { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Radio> Radios { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet <Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }

    }
}
