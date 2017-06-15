namespace _02E.KnightsOfHonor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            var input = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            Action<List<string>> action = s => s.ForEach(x => Console.WriteLine($"Sir {x}"));

            action(input);
        }
    }
}