namespace _10E.Chain
{
    using System;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Chain
    {
        public static void Main()
        {
            byte[] inputBuffer = new byte[1024];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            var htmlText = Console.ReadLine();
            var sb = new StringBuilder();
            var aTomString = "abcdefghijklm";
            var nTozString = "nopqrstuvwxyz";
            var pTagRegex = new Regex(@"<p>(.+?)<\/p>");
            var spaceRegex = new Regex(@"[^a-z0-9]+");

            var pMatches = pTagRegex.Matches(htmlText);

            foreach (Match subText in pMatches)
            {
                var currentSubText = subText.Groups[1].Value;
                sb.Append(spaceRegex.Replace(currentSubText, " "));
            }

            for (int i = 0; i < sb.Length; i++)
            {
                var currentLetter = sb[i];

                var aTomIndex = aTomString.IndexOf(currentLetter);

                if (aTomIndex != -1)
                {
                    var letter = nTozString[aTomIndex];
                    sb.Replace(sb[i], letter, i, 1);
                    continue;
                }

                var nTozIndex = nTozString.IndexOf(currentLetter);

                if (nTozIndex != -1)
                {
                    var letter = aTomString[nTozIndex];
                    sb.Replace(sb[i], letter, i, 1);
                    continue;
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}