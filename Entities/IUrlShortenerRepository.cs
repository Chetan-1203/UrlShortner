using UrlShortner.Models;

namespace UrlShortner.Entities
{
    public interface IUrlShortenerRepository
    {
        Task SaveShortenUrl(ShortenedUrl req , string code);

        Task<bool> IsCodePresent(ShortenedUrl req , string code);
    }
}
