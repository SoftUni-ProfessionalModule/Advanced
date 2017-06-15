namespace _04E.EvensOrOdds
{
    using System;

    public class EvensOrOdds
    {
        public static void Main()
        {
            var interval = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var from = int.Parse(interval[0]);
            var to = int.Parse(interval[1]);
            var command = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            for (int i = from; i <= to; i++)
            {
                if (command == "even")
                {
                    if (isEven(i))
                    {
                        Console.Write(i + " ");
                    }

                    continue;
                }

                if (isOdd(i))
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
        }
    }
}