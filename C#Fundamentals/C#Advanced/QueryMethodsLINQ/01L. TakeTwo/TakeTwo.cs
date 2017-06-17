namespace _01L.TakeTwo
{
    using System;
    using System.Linq;

    public class TakeTwo
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var filteredNumbers = numbers.Where(x => x >= 10 && x <= 20)
                .Distinct()
                .Take(2)
                .ToArray();

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}