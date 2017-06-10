namespace _06E.CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            var inputText = Console.ReadLine().ToLower();
            var inputString = Console.ReadLine().ToLower();

            var occurrenceCounter = 0;

            var index = inputText.IndexOf(inputString);

            while (index != -1)
            {
                occurrenceCounter++;

                index = inputText.IndexOf(inputString, index + 1);
            }

            Console.WriteLine(occurrenceCounter);
        }
    }
}