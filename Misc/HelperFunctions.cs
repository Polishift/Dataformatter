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
    }
}