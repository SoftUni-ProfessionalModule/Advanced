namespace _14E.LettersChangeNumbers
{
    using System;
    using System.Collections.Generic;

    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var upperLetterAndPossition = new Dictionary<char, double>();
            var lowerLetterAndPossition = new Dictionary<char, double>();

            var upperLetterAsDigit = 65;
            var lowerLetterAsDigit = 97;

            for (int i = 1; i <= 26; i++)
            {
                var currentUpperLetter = (char)upperLetterAsDigit;
                upperLetterAndPossition.Add(currentUpperLetter, i);

                upperLetterAsDigit++;
            }

            for (int i = 1; i <= 26; i++)
            {
                var currentLowerLetter = (char)lowerLetterAsDigit;
                lowerLetterAndPossition.Add(currentLowerLetter, i);

                lowerLetterAsDigit++;
            }

            var inputLine = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;

            for (int i = 0; i < inputLine.Length; i++)
            {
                var currentString = inputLine[i];
                var number = double.Parse(currentString.Substring(1, currentString.Length - 2));
                var firstLetter = currentString[0];
                var secondLetter = currentString[currentString.Length - 1];
                var firstPossition = 0.0;
                var secondPossition = 0.0;

                if (char.IsUpper(firstLetter))
                {
                    firstPossition = upperLetterAndPossition[firstLetter];

                    number /= firstPossition;
                }
                else
                {
                    firstPossition = lowerLetterAndPossition[firstLetter];
                    number *= firstPossition;
                }
                if (char.IsUpper(secondLetter))
                {
                    secondPossition = upperLetterAndPossition[secondLetter];
                    number -= secondPossition;
                }
                else
                {
                    secondPossition = lowerLetterAndPossition[secondLetter];
                    number += secondPossition;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}