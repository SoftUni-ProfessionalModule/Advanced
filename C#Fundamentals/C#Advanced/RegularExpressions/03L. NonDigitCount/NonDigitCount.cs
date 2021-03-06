﻿namespace _03L.NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"\D");

            var matches = regex.Matches(text);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}