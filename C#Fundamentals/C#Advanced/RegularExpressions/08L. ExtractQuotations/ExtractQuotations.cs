namespace _08L.ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractQuotations
    {
        public static void Main()
        {
            var inputText = Console.ReadLine();

            var regex = new Regex(@"(['""])(.+?)\1");

            var matches = regex.Matches(inputText);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[2]);
            }
        }
    }
}