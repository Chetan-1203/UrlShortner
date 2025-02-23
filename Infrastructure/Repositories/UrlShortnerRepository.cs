using UrlShortner.Entities;
using UrlShortner.Models;

namespace UrlShortner.Infrastructure.Repositories
{
    public class UrlShortnerRepository : IUrlShortnerRepository
    {
        
        public Task<string> SaveShortenUrl(UrlShortnerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
