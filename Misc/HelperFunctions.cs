using System.Globalization;

namespace Dataformatter.Misc
{
    public static class HelperFunctions
    {
        public static string StripOnSpaces(string input)
        {
            if (input.Equals(""))
                return "-1";

            var output = input.Substring(0, input.IndexOf(' '));
            return output;
        }

        public static string ReplaceCommasInThousands(string input)
        {
            if (input.Equals(""))
                return "-1";

            var output = input.Replace(",", "");
            return output;
        }

        public static string StripOnPercent(string input)
        {
            var output = input.Substring(0, input.IndexOf('%'));
            return output;
        }
        
        public static double ToDouble(this string value)
        {
            double result;
            //Try parsing in the current culture
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                //Then try in US english
                !double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                //Then in neutral language
                !double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = 0.0;
            }

            return result;
        }
    }
}