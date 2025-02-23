using UrlShortner.Entities;
using UrlShortner.Models;

namespace UrlShortner.Infrastructure.Repositories
{
    public class UrlShortnerRepository : IUrlShortnerRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public UrlShortnerRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<string> SaveShortenUrl(ShortenedUrl request, string code)
        {
            while (true)
            {
                if (!_dbcontext.ShortenUrls.Any(url => url.Code.Equals(code)){
                    await _dbcontext.ShortenUrls.AddAsync(request);
                    await _dbcontext.SaveChangesAsync();
                    return request.ShortUrl;
                }

            }
        }
    }
}
