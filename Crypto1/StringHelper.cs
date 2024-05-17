using System.Text.RegularExpressions;

namespace Crypto1;

public static partial class StringHelper
{
    public static string NormalizeString(string stringToNormalize)
    {
        return RegexLowerCaseLetter().Replace(stringToNormalize.ToLower(), "");
    }

    [GeneratedRegex("[^a-z]")]
    private static partial Regex RegexLowerCaseLetter();
}