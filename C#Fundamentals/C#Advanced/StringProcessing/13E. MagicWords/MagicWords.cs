namespace _13E.MagicWords
{
    using System;
    using System.Collections.Generic;

    public class MagicWords
    {
        public static void Main()
        {
            var wordsInput = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            var firstWord = wordsInput[0];
            var secondWord = wordsInput[1];

            if (CheckIsWordsMagic(firstWord, secondWord))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

        public static bool CheckIsWordsMagic(string firstWord, string secondWord)
        {
            var isMagic = false;

            var firstWordUnique = new HashSet<char>();

            for (int i = 0; i < firstWord.Length; i++)
            {
                firstWordUnique.Add(firstWord[i]);
            }

            var secondWordUnique = new HashSet<char>();

            for (int i = 0; i < secondWord.Length; i++)
            {
                secondWordUnique.Add(secondWord[i]);
            }

            if (firstWordUnique.Count == secondWordUnique.Count)
            {
                isMagic = true;
            }

            return isMagic;
        }
    }
}