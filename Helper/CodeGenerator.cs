namespace UrlShortner.Helper
{
    public static class CodeGenerator
    {
        public const int CharsInShortLink = 7;
        public const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        

        public static string GenerateCode()
        {
            Random random = new();
            char[] code = new char[CharsInShortLink];

            for (int i = 0; i < CharsInShortLink; i++)
            {
                var randomIndex = random.Next(Characters.Length - 1);
                code[i] = Characters[randomIndex];
            }

            return code.ToString() ?? string.Empty;
        }
    }
}
