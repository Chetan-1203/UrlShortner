using UrlShortner.Infrastructure;

namespace UrlShortner.Services
{   
    public class UrlShortnerService
    {   
        private readonly ApplicationDbContext _dbcontext;
        public const int CharsInShortLink = 7;
        public UrlShortnerService(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


    }
}
