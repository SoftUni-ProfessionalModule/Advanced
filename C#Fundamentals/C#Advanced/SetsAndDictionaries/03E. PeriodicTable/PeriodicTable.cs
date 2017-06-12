namespace _03E.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    public class PeriodicTable
    {
        public static void Main()
        {
            var numberOfChemicals = int.Parse(Console.ReadLine());

            var uniqueChemicals = new SortedSet<string>();

            for (int i = 0; i < numberOfChemicals; i++)
            {
                var chemicals = Console.ReadLine().Split();

                foreach (var chemical in chemicals)
                {
                    uniqueChemicals.Add(chemical);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueChemicals));
        }
    }
}