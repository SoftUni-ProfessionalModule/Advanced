namespace _05L.ExtractTags
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main()
        {
            var lines = Console.ReadLine();
            var regex = new Regex(@"<.+?>");
            var lineList = new List<string>();

            while (lines != "END")
            {
                var matches = regex.Matches(lines);

                foreach (Match match in matches)
                {
                    lineList.Add(match.Value);
                }

                lines = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, lineList));
        }
    }
}