namespace _12E.LittleJohn
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        public static void Main()
        {
            var pattern = @">>>----->>|>>----->|>----->";

            var arrowsRegex = new Regex(pattern);

            var largeArrowsCount = 0;
            var mediumArrowsCount = 0;
            var smallArrowsCount = 0;

            for (int i = 0; i < 4; i++)
            {
                var line = Console.ReadLine();
                var matches = arrowsRegex.Matches(line);

                foreach (Match match in matches)
                {
                    switch (match.Value)
                    {
                        case ">>>----->>":
                            largeArrowsCount++;
                            break;
                        case ">>----->":
                            mediumArrowsCount++;
                            break;
                        case ">----->":
                            smallArrowsCount++;
                            break;
                    }
                }
            }

            var allArrowsNumber = int.Parse(smallArrowsCount + "" + mediumArrowsCount + "" + largeArrowsCount);
            var decToBinary = Convert.ToString(allArrowsNumber, 2);
            var reversedBinary = new StringBuilder();
            reversedBinary.Append(decToBinary);

            for (int i = decToBinary.Length - 1; i >= 0; i--)
            {
                reversedBinary.Append(decToBinary[i]);
            }

            var result = Convert.ToInt32(reversedBinary.ToString(), 2).ToString();
            Console.WriteLine(result);
        }
    }
}