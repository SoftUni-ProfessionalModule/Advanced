namespace _02E.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var n = int.Parse(input[0]);
            var m = int.Parse(input[1]);

            var setWithN = new HashSet<string>();
            var setWithM = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                setWithN.Add(Console.ReadLine());
            }
            for (int i = 0; i < m; i++)
            {
                setWithM.Add(Console.ReadLine());
            }

            setWithN.IntersectWith(setWithM);

            Console.WriteLine(string.Join(" ", setWithN));
        }
    }
}