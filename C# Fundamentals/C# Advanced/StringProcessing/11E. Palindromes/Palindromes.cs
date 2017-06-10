namespace _04L.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Palindromes
    {
        public static void Main()
        {
            var words = Console.ReadLine()
                .Split(new char[] { ' ', ',', '!', '?', '.' }
                , StringSplitOptions.RemoveEmptyEntries);

            var reversedWord = new StringBuilder();
            var palindromes = new SortedSet<string>();

            foreach (var word in words)
            {

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversedWord.Append(word[i]);
                }

                var result = string.Compare(word, reversedWord.ToString());

                if (result == 0)
                {
                    palindromes.Add(word);
                }

                reversedWord.Clear();
            }

            Console.WriteLine("[" + string.Join(", ", palindromes) + "]");
        }
    }
}