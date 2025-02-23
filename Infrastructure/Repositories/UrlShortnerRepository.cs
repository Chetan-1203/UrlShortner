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
                if (!_dbcontext.ShortenedUrls.Any(url => url.Code.Equals(code))){
                    await _dbcontext.ShortenedUrls.AddAsync(request);
                    await _dbcontext.SaveChangesAsync();
                    return request.ShortUrl;
                }

            }
        }
    }
}
