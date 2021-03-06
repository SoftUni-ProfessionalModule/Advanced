﻿namespace _07L.BoundedNumbers
{
    using System;
    using System.Linq;

    public class BoundedNumbers
    {
        public static void Main()
        {
            var bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(n => n)
                .ToArray();

            var lowerBound = bounds[0];
            var upperBound = bounds[1];

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => lowerBound <= n && n <= upperBound)
                .ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}