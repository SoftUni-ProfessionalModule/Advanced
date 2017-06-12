namespace _11E.SemanticHTML
{
    using System;
    using System.Text.RegularExpressions;
    using System.Text;

    public class SemanticHTML
    {
        public static void Main()
        { 
            // TO DO check regex for openning tah below !!!
            //var x = @"<(div)([^>]+)(?:id|class)\s*=\s*\""(.*?)""(.*?)>";
            var inputLine = Console.ReadLine();
            var openTagRegex = new Regex(@"<div(?:\s*.+)?\s+(\w+\s?=\s?""(\w +)"")\s*(\s.+)?>");
            var closeTagRegex = new Regex(@"<\/div>\s*<!--\s*(\w+)\s*-->");
            var result = new StringBuilder();

            while (inputLine != "END")
            {
                var openTagMatch = openTagRegex.Match(inputLine);
                var closeTagMatch = closeTagRegex.Match(inputLine);

                if (openTagMatch.Success)
                {
                    result.AppendLine
                        ($"<{openTagMatch.Groups[2].Value}{openTagMatch.Groups[1].Value}{openTagMatch.Groups[3].Value}>");
                }
                else if (closeTagMatch.Success)
                {
                    result.AppendLine($"</{closeTagMatch.Groups[1].Value}>");
                }
                else
                {
                    result.AppendLine(inputLine);
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(result.ToString());
        }
    }
}