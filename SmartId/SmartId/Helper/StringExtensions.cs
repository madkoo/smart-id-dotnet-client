namespace SmartId.Helper
{
    public static class StringExtensions
    {
        public static string GetLast(this string s, int length)
        {
            var index = s.Length - length;
            return (s.Length > length)
                ? s.Substring(index, length) : s;
        }

        public static string EnsureEndsWith(this string s, string value)
        {
            if (s.EndsWith('/'))
                return s;
            return $"{s}/";
        }
    }
}
