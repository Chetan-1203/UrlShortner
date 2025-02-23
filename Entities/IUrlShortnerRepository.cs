using UrlShortner.Models;

namespace UrlShortner.Entities
{
    public interface IUrlShortnerRepository
    {
        Task<string> SaveShortenUrl(ShortenedUrl req , string code);
    }
}
