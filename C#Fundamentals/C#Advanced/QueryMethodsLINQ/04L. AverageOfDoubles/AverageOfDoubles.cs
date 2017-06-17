namespace _04L.AverageOfDoubles
{
    using System;
    using System.Linq;

    public class AverageOfDoubles
    {
        public static void Main()
        {
            var avarageNumber = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{avarageNumber:f2}");
        }
    }
}