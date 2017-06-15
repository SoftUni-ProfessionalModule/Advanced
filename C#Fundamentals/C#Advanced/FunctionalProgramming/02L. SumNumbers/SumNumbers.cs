namespace _02L.SumNumbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine();

            Func<string, int> parseNumbers = n => int.Parse(n);

            Console.WriteLine(numbers
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parseNumbers)
                .Count());
            Console.WriteLine(numbers
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parseNumbers)
                .Sum());
        }
    }
}