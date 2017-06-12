namespace _01L.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchCount
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            var regex = new Regex(word);

            var match = regex.Matches(text);

            Console.WriteLine(match.Count);
        }
    }
}