namespace _01E.MatchFullName
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            var text = Console.ReadLine(); ;
            var pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            var validNames = new List<string>();

            var regex = new Regex(pattern);

            while (text != "end")
            {
                var match = regex.Match(text);

                if (match.Success)
                {
                    validNames.Add(match.Groups[0].Value);
                }

                text = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, validNames));
        }
    }
}