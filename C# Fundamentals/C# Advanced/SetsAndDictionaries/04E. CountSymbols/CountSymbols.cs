namespace _04E.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var symbolsDict = new SortedDictionary<char, int>();

            foreach (var symbol in text)
            {
                if (!symbolsDict.ContainsKey(symbol))
                {
                    symbolsDict.Add(symbol, 1);
                }
                else
                {
                    symbolsDict[symbol]++;
                }
            }

            foreach (var symbolCount in symbolsDict)
            {
                Console.WriteLine($"{symbolCount.Key}: {symbolCount.Value} time/s");
            }
        }
    }
}