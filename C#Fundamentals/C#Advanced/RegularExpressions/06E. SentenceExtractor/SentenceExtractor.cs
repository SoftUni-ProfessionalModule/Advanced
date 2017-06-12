namespace _06E.SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();
            var sentenseRegex = new Regex(@"[^\.\?!\t\n]+[\.\?!]");
            var wordRegex = new Regex($@"\b{word}\b");
            var sentenseMatches = sentenseRegex.Matches(text);

            foreach (Match sentense in sentenseMatches)
            {
                var currentSentense = sentense.Value;
                var wordMatch = wordRegex.Match(currentSentense);

                if (wordMatch.Success)
                {
                    Console.WriteLine(currentSentense);
                }
            }
        }
    }
}