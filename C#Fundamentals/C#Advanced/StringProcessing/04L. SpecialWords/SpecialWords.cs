namespace _04L.SpecialWords
{
    using System;
    using System.Text;

    public class SpecialWords
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine()
                .Split(new[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();
            var sbText = new StringBuilder();
            sbText.Append(text);

            foreach (var word in specialWords)
            {
                var currentWordCounter = 0;
                var index = text.IndexOf(word);

                while (index != -1)
                {
                    if (index + word.Length != text.Length)
                    {
                        if (!char.IsLetter(text[index + word.Length]))
                        {
                            currentWordCounter++;
                        }
                    }
                    else
                    {
                        currentWordCounter++;
                    }

                    index = text.IndexOf(word, index + 1);
                }

                Console.WriteLine($"{word} - {currentWordCounter}");
            }
        }
    }
}