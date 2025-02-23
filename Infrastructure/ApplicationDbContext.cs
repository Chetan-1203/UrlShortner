using Microsoft.EntityFrameworkCore;
using UrlShortner.Entities;
using UrlShortner.Services;

namespace UrlShortner.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {    
        public DbSet<ShortenedUrl> ShortenUrls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>(builder =>
            {
                builder.Property(url => url.Code)
                .HasMaxLength(UrlShortnerService.CharsInShortLink);
                builder.HasIndex(url => url.Code).IsUnique();
            });
        }
    }
}
