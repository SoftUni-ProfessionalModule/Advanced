namespace _03L.FirstName
{
    using System;
    using System.Linq;

    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split();
            var sequenceOfLetters = Console.ReadLine().Split().OrderBy(l => l).ToArray();
            string filteredName;
            var isNameFound = false;

            foreach (var letter in sequenceOfLetters)
            {
                filteredName = names.Where(n => n.StartsWith(letter, true, null)).FirstOrDefault();

                if (filteredName != null)
                {
                    isNameFound = true;
                    Console.WriteLine(filteredName);
                    break;
                }
            }

            if (!isNameFound)
            {
                Console.WriteLine("No match");
            }
        }
    }
}