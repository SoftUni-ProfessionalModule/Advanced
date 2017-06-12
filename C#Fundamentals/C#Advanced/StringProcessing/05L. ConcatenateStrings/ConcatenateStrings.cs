namespace _05L.ConcatenateStrings
{
    using System;
    using System.Text;

    public class ConcatenateStrings
    {
        public static void Main()
        {
            var numberOfWords = int.Parse(Console.ReadLine());

            var text = new StringBuilder();

            for (int i = 0; i < numberOfWords; i++)
            {
                var currentWord = Console.ReadLine();

                text.Append(currentWord);
                text.Append(" ");
            }

            Console.WriteLine(text.ToString());
        }
    }
}