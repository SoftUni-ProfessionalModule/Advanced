namespace _06E.ReverseAndExclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var devider = int.Parse(Console.ReadLine());

            Func<int[], int[]> reversedNumbers = n => n.Reverse().ToArray();
            numbers = reversedNumbers(numbers);
            Predicate<int> isDivisibleByDivider = n => n % devider != 0;

            Console.WriteLine(string.Join(" ", numbers.Where(x => isDivisibleByDivider(x))));
        }
    }
}