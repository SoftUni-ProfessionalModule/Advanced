namespace _03E.SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"(.)\1+");

            Console.WriteLine(regex.Replace(text, "$1"));
        }
    }
}