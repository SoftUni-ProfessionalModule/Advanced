namespace _12E.CharacterMultiplier
{
    using System;

    public class CharacterMultiplier
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine().Split(new char[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
            var firstString = inputLine[0];
            var secondString = inputLine[1];

            Console.WriteLine(Multiplier(firstString, secondString));
        }

        public static long Multiplier(string firstString, string secondString)
        {
            var minLength = Math.Min(firstString.Length, secondString.Length);
            long result = 0;

            for (int i = 0; i < minLength; i++)
            {
                result += firstString[i] * secondString[i];
            }

            var largerString = firstString.Length > secondString.Length ? firstString : secondString;
            largerString = largerString.Remove(0, minLength);

            for (int i = 0; i < largerString.Length; i++)
            {
                result += largerString[i];
            }

            return result;
        }
    }
}