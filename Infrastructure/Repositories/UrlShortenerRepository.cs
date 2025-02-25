using MongoDB.Driver;
using UrlShortner.Entities;
using UrlShortner.Models;

namespace UrlShortner.Infrastructure.Repositories
{
    public class UrlShortenerRepository : IUrlShortenerRepository
    {
        private readonly IMongoCollection<ShortenedUrl> _urlCollection;

        public UrlShortenerRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDbSettings:DatabaseName"]);
            _urlCollection = database.GetCollection<ShortenedUrl>("ShortenedUrls");
        }

        public async Task<string> GetOriginalUrl(string code)
        {
            var shortenedUrl = await _urlCollection
                .Find(url => url.Code.Equals(code)).FirstOrDefaultAsync();
            return shortenedUrl.OriginalUrl;
        }

        public async Task<string> GetShortenUrl(string longUrl)
        {
            var shortenedUrl = await _urlCollection
                .Find(url => url.OriginalUrl.Equals(longUrl)).FirstOrDefaultAsync();
            return shortenedUrl.ShortUrl;
        }

        public async Task<bool> IsCodePresent(string code)
        {
            return await _urlCollection.Find(url => url.Code.Equals(code)).AnyAsync();

        }

        public  async Task<bool> IsOriginalUrlPresent(string longUrl)
        {
            return await _urlCollection.Find(url => url.OriginalUrl.Equals(longUrl)).AnyAsync();
        }

        public async Task SaveShortenUrl(ShortenedUrl request, string code)
        {
            await _urlCollection.InsertOneAsync(request);
        }
    }
}
