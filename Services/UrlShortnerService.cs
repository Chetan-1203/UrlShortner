using UrlShortner.Entities;
using UrlShortner.Helper;
using UrlShortner.Infrastructure;
using UrlShortner.Models;

namespace UrlShortner.Services
{
    public class UrlShortnerService
    {
        private readonly IUrlShortnerRepository _urlShortner;
        private readonly HttpContext _httpContext;

        public UrlShortnerService(IUrlShortnerRepository urlShortner
            HttpContext httpContext)
        {
            _urlShortner = urlShortner;
            _httpContext = httpContext;
        }

        public async Task<string> SaveShortenedUrl(UrlShortnerRequest request)
        {
            var code = CodeGenerator.GenerateCode();
            var shortUrl = $"{_httpContext.Request.Scheme}" +
                $"://{_httpContext.Request.Host}/api/{code}";
            var shortnedUrl = new ShortenedUrl(code,
                request.Url,
                shortUrl);
            return await _urlShortner.SaveShortenUrl(shortnedUrl, code);
        }
    }
}
