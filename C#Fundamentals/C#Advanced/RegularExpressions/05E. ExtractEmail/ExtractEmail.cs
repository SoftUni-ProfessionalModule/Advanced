namespace _05E.ExtractEmail
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmail
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = @"((?<=\s)[A-Za-z0-9]+(\.?|-?|_)[A-Za-z0-9]+@[A-Za-z]+([\-\.][A-Za-z]+)*(\.[A-Za-z]+))";
            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[1]);
            }
        }
    }
}