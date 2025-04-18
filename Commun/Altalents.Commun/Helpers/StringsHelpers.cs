namespace Altalents.Commun.Helpers
{
    public static class StringsHelpers
    {
        public static string HtmlToPlainText(string text)
        {
            if (text == null)
            {
                return string.Empty;
            }

            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";   // matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";       // match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>"; // matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            Regex lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            Regex stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            Regex tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            return text;
        }

        public static string FirstLetterToUpperCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }

        public static string EnsureEndsWithQuestionMark(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            str = str.Trim();
            return str.EndsWith("?") ? str : str + "?";
        }

    }
}
