namespace _15E.MelrahShake
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstIndex = inputLine.IndexOf(pattern);
                var lastIndex = inputLine.LastIndexOf(pattern);

                if (firstIndex >= 0 && lastIndex > firstIndex)
                {
                    inputLine = inputLine.Remove(lastIndex, pattern.Length);
                    inputLine = inputLine.Remove(firstIndex, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);

                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                if (pattern == string.Empty)
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }

            Console.WriteLine(string.Join("", inputLine));
        }
    }
}