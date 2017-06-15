namespace _05E.AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> addOne = n => n.Select(x => x + 1).ToArray();
            Func<int[], int[]> subtractOne = n => n.Select(x => x - 1).ToArray();
            Func<int[], int[]> multiplyByTwo = n => n.Select(x => x * 2).ToArray();
            Action<int[]> printArray = n => Console.WriteLine(string.Join(" ", n));

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = addOne(numbers);
                        break;
                    case "subtract":
                        numbers = subtractOne(numbers);
                        break;
                    case "multiply":
                        numbers = multiplyByTwo(numbers);
                        break;
                    case "print":
                        printArray(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}