namespace UrlShortner.Entities
{
    public class ShortenedUrl
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedOn { get; set; }

        public ShortenedUrl(
            string code,
            string originalUrl,
            string shortUrl)
        {
            Id = new Guid();
            Code = code;
            OriginalUrl = originalUrl;
            ShortUrl = shortUrl;
            CreatedOn = DateTime.Now;
        }
    }
}
