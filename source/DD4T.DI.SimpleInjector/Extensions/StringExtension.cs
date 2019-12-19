using System.Linq;

namespace DD4T.DI.SimpleInjector.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Return whether the value starts with the any of the texts
        /// </summary>
        /// <param name="texts">The texts.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool TextStartsWith(this string texts, string value)
        {
            return !string.IsNullOrWhiteSpace(texts) && texts.ToLowerInvariant().Split(',').Select(x => x.Trim())
                       .Any(x => value.ToLowerInvariant().StartsWith(x));
        }
    }
}
