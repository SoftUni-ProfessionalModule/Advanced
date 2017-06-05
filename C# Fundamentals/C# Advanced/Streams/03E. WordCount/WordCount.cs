namespace _03E.WordCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class WordCount
    {
        public static void Main()
        {
            var textReader = new StreamReader("text.txt");
            var wordsReader = new StreamReader("words.txt");
            var writer = new StreamWriter("result.txt");
            var wordsCounterDict = new Dictionary<string, int>();

            using (textReader)
            {
                using (wordsReader)
                {
                    using (writer)
                    {
                        var currentWord = wordsReader.ReadLine();

                        while (currentWord != null)
                        {
                            wordsCounterDict.Add(currentWord, 0);

                            currentWord = wordsReader.ReadLine();
                        }

                        var currentTextLine = textReader.ReadLine();

                        while (currentTextLine != null)
                        {
                            var wordsInText = currentTextLine
                                .ToLower()
                                .Split(new char[] { ' ', ',', '.', '?', '!', '-' }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (var word in wordsInText)
                            {
                                if (wordsCounterDict.ContainsKey(word))
                                {
                                    wordsCounterDict[word]++;
                                }
                            }

                            currentTextLine = textReader.ReadLine();
                        }

                        foreach (var word in wordsCounterDict.OrderByDescending(x => x.Value))
                        {
                            writer.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}