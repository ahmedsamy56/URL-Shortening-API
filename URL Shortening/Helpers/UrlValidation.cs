using System.Text.RegularExpressions;

namespace URL_Shortening.Helpers
{
    public static class UrlValidation
    {

        public static bool isValidURL(string str)
        {
            string strRegex = @"((http|https)://)(www.)?" +
              "[a-zA-Z0-9@:%._\\+~#?&//=]" +
              "{2,256}\\.[a-z]" +
              "{2,6}\\b([-a-zA-Z0-9@:%" +
              "._\\+~#?&//=]*)";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(str))
                return (true);
            else
                return (false);
        }
    }
}
