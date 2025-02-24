using UrlShortner.Entities;
using UrlShortner.Helper;
using UrlShortner.Infrastructure;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UrlShortenerService
    {
        private readonly IUrlShortenerRepository _urlShortener;

        public UrlShortenerService(IUrlShortenerRepository urlShortener)
        {
            _urlShortener = urlShortener;
        }

        public async Task<string> SaveShortenedUrl(UrlShortenerRequest request,
            HttpContext context)
        {
            while (true)
            {
                var code = CodeGenerator.GenerateCode();
                var shortUrl = $"{context.Request.Scheme}" +
                               $"://{context.Request.Host}/api/{code}";
                var shortenedUrl = new ShortenedUrl(code,
                    request.Url,
                    shortUrl);
                if (!await _urlShortener.IsCodePresent(shortenedUrl, code))
                {  
                    await _urlShortener.SaveShortenUrl(shortenedUrl, code);
                    return shortenedUrl.ShortUrl;
                }
              
            }

        }
    }
}
