namespace _09E.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> isDivisible = (n,i) => n % i == 0;
            var resultedNumbers = new List<int>();

            var start = dividers.Min();

            for (int i = start; i <= range; i++)
            {
                var isPass = true;
                foreach (var devider in dividers)
                {
                    if (!isDivisible(i,devider))
                    {
                        isPass = false;
                        break;
                    }
                }

                if (isPass)
                {
                    resultedNumbers.Add(i);                    
                }
            }

            Console.WriteLine(string.Join(" ", resultedNumbers));
        }
    }
}