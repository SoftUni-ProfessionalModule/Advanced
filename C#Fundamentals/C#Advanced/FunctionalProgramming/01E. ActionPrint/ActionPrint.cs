namespace _01E.ActionPrint
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ActionPrint
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Action<List<string>> action = s => s.ForEach(x => Console.WriteLine(x));

            action(input);
        }
    }
}