namespace _02L.VowelCount
{
    using System;
    using System.Text.RegularExpressions;
    
    public class VowelCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"[aeiouyAEIOUY]");

            var matches = regex.Matches(text);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}