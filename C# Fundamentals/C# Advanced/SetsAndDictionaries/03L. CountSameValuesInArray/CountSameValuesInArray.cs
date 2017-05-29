namespace _03L.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dict = new SortedDictionary<double, int>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                var currentDigit = inputLine[i];

                if (!dict.ContainsKey(currentDigit))
                {
                    dict.Add(currentDigit, 1);
                }
                else
                {
                    dict[currentDigit]++;
                }
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}