namespace _03L.GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var divider = 3;

            var zero = numbers.Where(x => Math.Abs(x) % divider == 0);
            var one = numbers.Where(x => Math.Abs(x) % divider == 1);
            var two = numbers.Where(x => Math.Abs(x) % divider == 2);

            Console.WriteLine(string.Join(" ", zero));
            Console.WriteLine(string.Join(" ", one));
            Console.WriteLine(string.Join(" ", two));
        }
    }
}