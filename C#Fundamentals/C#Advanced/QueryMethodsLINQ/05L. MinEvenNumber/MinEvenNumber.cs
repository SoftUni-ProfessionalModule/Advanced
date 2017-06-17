namespace _05L.MinEvenNumber
{
    using System;
    using System.Linq;

    public class MinEvenNumber
    {
        public static void Main()
        {
            var evenNumbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Where(n => n % 2 == 0)
                .ToArray();

            if (evenNumbers.Length > 0)
            {
                Console.WriteLine($"{evenNumbers.Min():f2}");
                return;
            }

            Console.WriteLine("No match");
        }
    }
}