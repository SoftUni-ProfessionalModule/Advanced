namespace _02E.MatchPhoneNumber
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var validNumbers = new List<string>();

            var pattern = @"\+359(\s|-)2\1\d{3}\1\d{4}\b";

            var regex = new Regex(pattern);

            while (inputLine != "end")
            {
                var match = regex.Match(inputLine);

                if (match.Success)
                {
                    validNumbers.Add(match.Groups[0].Value);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, validNumbers));
        }
    }
}