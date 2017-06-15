namespace _07E.PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var inputNames = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, List<string>> names = n => n.Where(x => x.Length <= length).ToList();

            names(inputNames).ForEach(n => Console.WriteLine(n));
        }
    }
}