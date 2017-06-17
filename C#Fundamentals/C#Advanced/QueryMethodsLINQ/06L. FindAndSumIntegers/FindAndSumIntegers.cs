namespace _06L.FindAndSumIntegers
{
    using System;
    using System.Linq;

    public class FindAndSumIntegers
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split()
                .Where((e, x) => int.TryParse(e, out x))
                .ToArray();

            if (numbers.Length > 0)
            {
                Console.WriteLine($"{numbers.Select(long.Parse).Sum()}");
                return;
            }

            Console.WriteLine("No match");
        }
    }
}