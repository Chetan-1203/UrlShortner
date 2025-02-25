
namespace UrlShortner.Entities
{
    public interface IUrlShortenerRepository
    {
        Task SaveShortenUrl(ShortenedUrl req , string code);

        Task<string> GetShortenUrl(string longUrl);

        Task<string> GetOriginalUrl(string code);

        Task<bool> IsCodePresent(string code);

        Task<bool> IsOriginalUrlPresent(string longUrl);
    }
}
