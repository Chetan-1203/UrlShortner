using Microsoft.EntityFrameworkCore;
using UrlShortner.Entities;
using UrlShortner.Helper;


namespace UrlShortner.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {    
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenedUrl>(builder =>
            {
                builder.Property(url => url.Code)
                .HasMaxLength(CodeGenerator.CharsInShortLink);
                builder.HasIndex(url => url.Code).IsUnique();
            });
        }
    }
}
