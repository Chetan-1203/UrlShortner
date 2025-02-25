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
            if (await _urlShortener.IsOriginalUrlPresent(request.Url))
            {
                return await _urlShortener.GetShortenUrl(request.Url);
            }
            while (true)
            {   
                var code = CodeGenerator.GenerateCode();
                var shortUrl = $"{context.Request.Scheme}" +
                               $"://{context.Request.Host}/api/{code}";
                var shortenedUrl = new ShortenedUrl(code,
                    request.Url,
                    shortUrl);
                if (!await _urlShortener.IsCodePresent(code))
                {  
                    await _urlShortener.SaveShortenUrl(shortenedUrl, code);
                    return shortenedUrl.ShortUrl;
                }
              
            }

        }

        public async Task<string> Redirect(string code)
        {
            if (await _urlShortener.IsCodePresent(code))
            {
                var originalUrl = await _urlShortener.GetOriginalUrl(code);
                return originalUrl;
            }
            else
            {
                return string.Empty;
            }
        }
       
    }
}
