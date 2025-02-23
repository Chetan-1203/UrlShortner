using UrlShortner.Entities;
using UrlShortner.Helper;
using UrlShortner.Infrastructure;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UrlShortnerService
    {
        private readonly IUrlShortnerRepository _urlShortner;

        public UrlShortnerService(IUrlShortnerRepository urlShortner)
        {
            _urlShortner = urlShortner;
        }

        public async Task<string> SaveShortenedUrl(UrlShortnerRequest request,
            HttpContext context)
        {
            var code = CodeGenerator.GenerateCode();
            var shortUrl = $"{context.Request.Scheme}" +
                $"://{context.Request.Host}/api/{code}";
            var shortnedUrl = new ShortenedUrl(code,
                request.Url,
                shortUrl);
            return await _urlShortner.SaveShortenUrl(shortnedUrl, code);
        }
    }
}
