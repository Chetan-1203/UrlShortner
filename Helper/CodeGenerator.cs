using System.Text;

namespace UrlShortner.Helper
{
    public static class CodeGenerator
    {
        public const int CharsInShortLink = 7;
        public const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        

        public static string GenerateCode()
        {
            Random random = new();
            StringBuilder code = new(CharsInShortLink);

            for (int i = 0; i < CharsInShortLink; i++)
            {
                code.Append(Characters[random.Next(Characters.Length)]);
            }

            return code.ToString();
        }
    }
}
